#region Copyright
/*
 *  DynamicMethod Delegates
 * 
 *  Copyright (C) 2005 
 *      Alessandro Febretti <mailto:febret@gmail.com>
 *      SharpFactory
 */
#endregion

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Text;

namespace SharpFactory
{
    /// <summary>
    /// A fast method delegate to call user code.
    /// </summary>
    public delegate object DynamicMethodDelegate(object target, object[] args);

    class DynamicMethodDelegateFactory
    {
        /// <summary>
        /// Generates a DynamicMethodDelegate delegate from a MethodInfo object.
        /// </summary>
        public static DynamicMethodDelegate Create(MethodInfo method)
        {
            ParameterInfo[] parms = method.GetParameters();
            int numparams = parms.Length;
            
            Type[] _argTypes = { typeof(object), typeof(object[]) };

            // Create dynamic method and obtain its IL generator to
            // inject code.
            DynamicMethod dynam =
                new DynamicMethod(
                "", 
                typeof(object), 
                _argTypes, 
                typeof(DynamicMethodDelegateFactory));
            ILGenerator il = dynam.GetILGenerator();

            #region IL generation

            #region Argument count check

            // Define a label for succesfull argument count checking.
            Label argsOK = il.DefineLabel();

            // Check input argument count.
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Ldc_I4, numparams);
            il.Emit(OpCodes.Beq, argsOK);

            // Argument count was wrong, throw TargetParameterCountException.
            il.Emit(OpCodes.Newobj,
                typeof(TargetParameterCountException).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Throw);

            // Mark IL with argsOK label.
            il.MarkLabel(argsOK);

            #endregion

            #region Instance push

            // If method isn't static push target instance on top
            // of stack.
            if (!method.IsStatic)
            {
                // Argument 0 of dynamic method is target instance.
                il.Emit(OpCodes.Ldarg_0);
            }

            #endregion

            #region Standard argument layout

            // Lay out args array onto stack.
            int i = 0;
            while (i < numparams)
            {
                // Push args array reference onto the stack, followed
                // by the current argument index (i). The Ldelem_Ref opcode
                // will resolve them to args[i].

                // Argument 1 of dynamic method is argument array.
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldc_I4, i);
                il.Emit(OpCodes.Ldelem_Ref);

                // If parameter [i] is a value type perform an unboxing.
                Type parmType = parms[i].ParameterType;
                if (parmType.IsValueType)
                {
                    il.Emit(OpCodes.Unbox_Any, parmType);
                }

                i++;
            }

            #endregion

            #region Method call

            // Perform actual call.
            // If method is not final a callvirt is required
            // otherwise a normal call will be emitted.
            if (method.IsVirtual)
            {
                il.Emit(OpCodes.Callvirt, method);
            }
            else
            {
                il.Emit(OpCodes.Call, method);
            }

            if (method.ReturnType != typeof(void))
            {
                // If result is of value type it needs to be boxed
                if (method.ReturnType.IsValueType)
                {
                    il.Emit(OpCodes.Box, method.ReturnType);
                }
            }
            else
            {
                il.Emit(OpCodes.Ldnull);
            }

            // Emit return opcode.
            il.Emit(OpCodes.Ret);

            #endregion

            #endregion

            return (DynamicMethodDelegate)dynam.CreateDelegate(typeof(DynamicMethodDelegate));
        }

    }
}
