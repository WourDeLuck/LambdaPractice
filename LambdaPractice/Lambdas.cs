using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LambdaPractice
{
    /// <summary>
    /// Simple class on lambda expression.
    /// </summary>
    public class Lambdas
    {
        // String type to store the result of transformation
        public string stringLambda;

        /// <summary>
        /// Transforms expression to be like dis - (a,b) => new User() {FirstName = a, LastName = b}
        /// </summary>
        /// <returns>Expression delegate</returns>
        public Func<string, string, User> CreateLambda()
        {
            var createdType = typeof(User);
            var ctor = Expression.New(createdType);

            var fName = Expression.Parameter(typeof(string), "firstName");
            var lName = Expression.Parameter(typeof(string), "lastName");

            var firstNameProperty = createdType.GetProperty("FirstName");
            var firstNameAssignment = Expression.Bind(firstNameProperty, fName);
            var lastNameProperty = createdType.GetProperty("LastName");
            var lastNameAssignment = Expression.Bind(lastNameProperty, lName);

            var memberInit = Expression.MemberInit(ctor, firstNameAssignment, lastNameAssignment);

            var lambda = Expression.Lambda<Func<string, string, User>>(memberInit, fName, lName);
            Func<string, string, User> Func = lambda.Compile();
            stringLambda = lambda.ToString();

            return Func;
        }
    }
}
