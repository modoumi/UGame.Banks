namespace UGame.Banks.Service.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DuplicateUpdateOrderException:Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public DuplicateUpdateOrderException():base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public DuplicateUpdateOrderException(string msg):base(msg)
        {

        }
    }
}
