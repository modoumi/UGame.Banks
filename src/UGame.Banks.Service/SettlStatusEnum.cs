namespace UGame.Banks.Service
{
    /// <summary>
    /// 验证订单状态枚举
    /// </summary>
    public enum SettlStatusEnum
    {
        /// <summary>
        /// 初始
        /// </summary>
        Init=0,
        /// <summary>
        /// 一致
        /// </summary>
        Consistent=1,
        /// <summary>
        /// 我方成功，对方失败
        /// </summary>
        OwnSuccessOtherFail = 2,
        /// <summary>
        /// 我方失败,对方成功
        /// </summary>
        OwnFailOtherSuccess=3
    }
}
