//-----------------------------------------------------------------------
// <copyright file="ApiRequestException.cs" company="Auralia">
//     Copyright (C) 2013 Auralia
// </copyright>
//-----------------------------------------------------------------------

namespace Auralia.NationStates.Api
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when an error occurs during a request to the NationStates API.
    /// </summary>
    [Serializable]
    public class ApiRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        public ApiRequestException() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ApiRequestException(string message) 
            : base(message) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApiRequestException(string message, Exception inner) 
            : base(message, inner) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected ApiRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
