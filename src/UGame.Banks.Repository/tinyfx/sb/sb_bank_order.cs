/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-04-10 16: 28:07
 ******************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using MySql.Data.MySqlClient;
using System.Text;
using TinyFx.Data.MySql;

namespace UGame.Banks.Repository
{
	#region EO
	/// <summary>
	/// 银行订单表
	/// 【表 sb_bank_order 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_bank_orderEO : IRowMapper<Sb_bank_orderEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_bank_orderEO()
		{
			this.FromMode = 0;
			this.UserKind = 0;
			this.OrderType = 0;
			this.PaytypeID = 0;
			this.PaytypeChannel = 0;
			this.RecDate = DateTime.Now;
			this.PlanAmount = 0;
			this.AppRequestTime = DateTime.Now;
			this.IsFirstCashOfDay = false;
			this.Status = 0;
			this.TransMoney = 0.000000m;
			this.OrderMoney = 0.000000m;
			this.Amount = 0;
			this.OwnFee = 0.000m;
			this.UserFee = 0.000m;
			this.UserMoney = 0.00m;
			this.AmountBonus = 0;
			this.EndBonus = 0;
			this.SettlAmount = 0;
			this.SettlStatus = 0;
			this.CompleteFlag = 0;
			this.IsAddBalance = true;
			this.IsAuditOrder = false;
			this.UserFeeAmount = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalOrderID;
		/// <summary>
		/// 【数据库中的原始主键 OrderID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalOrderID
		{
			get { return _originalOrderID; }
			set { HasOriginal = true; _originalOrderID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "OrderID", OrderID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 订单编码GUID
		/// 【主键 varchar(38)】
		/// </summary>
		[DataMember(Order = 1)]
		public string OrderID { get; set; }
		/// <summary>
		/// 应用提供商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 2)]
		public string ProviderID { get; set; }
		/// <summary>
		/// 应用编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 3)]
		public string AppID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 4)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 用户编码(GUID)
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 5)]
		public string UserID { get; set; }
		/// <summary>
		/// 新用户来源方式
		///              0-获得运营商的新用户(s_operator)
		///              1-推广员获得的新用户（userid）
		///              2-推广渠道通过url获得的新用户（s_channel_url)
		///              3-推广渠道通过code获得的新用户（s_channel_code)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 6)]
		public int FromMode { get; set; }
		/// <summary>
		/// 对应的编码（根据FromMode变化）
		///              FromMode=
		///              0-运营商的新用户(s_operator)==> OperatorID
		///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
		///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
		///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 7)]
		public string FromId { get; set; }
		/// <summary>
		/// 域名（不带http）
		/// 【字段 varchar(255)】
		/// </summary>
		[DataMember(Order = 8)]
		public string DomainID { get; set; }
		/// <summary>
		/// 用户类型
		///              0-未知
		///              1-普通用户
		///              2-开发用户
		///              3-线上测试用户（调用第三方扣减）
		///              4-线上测试用户（不调用第三方扣减）
		///              5-仿真用户
		///              6-接口联调用户
		///              9-管理员
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 9)]
		public int UserKind { get; set; }
		/// <summary>
		/// 注册时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 10)]
		public DateTime? RegistDate { get; set; }
		/// <summary>
		/// 充值返现1-充值2-返现
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 11)]
		public int OrderType { get; set; }
		/// <summary>
		/// 银行编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 12)]
		public string BankID { get; set; }
		/// <summary>
		/// 支付方式0-综合1-visa2-spei
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 13)]
		public int PaytypeID { get; set; }
		/// <summary>
		/// 支付方式下的渠道
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 14)]
		public int PaytypeChannel { get; set; }
		/// <summary>
		/// 货币类型（货币缩写USD）
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 15)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 16)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// 计划变化金额（正负数）
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 17)]
		public long PlanAmount { get; set; }
		/// <summary>
		/// 请求唯一号
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 18)]
		public string AppRequestUUID { get; set; }
		/// <summary>
		/// app订单编码
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 19)]
		public string AppOrderId { get; set; }
		/// <summary>
		/// 请求备注
		/// 【字段 varchar(255)】
		/// </summary>
		[DataMember(Order = 20)]
		public string AppReqComment { get; set; }
		/// <summary>
		/// 请求时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 21)]
		public DateTime AppRequestTime { get; set; }
		/// <summary>
		/// 账户名称
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 22)]
		public string AccName { get; set; }
		/// <summary>
		/// 账户卡号
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 23)]
		public string AccNumber { get; set; }
		/// <summary>
		/// 银行编码
		/// 【字段 varchar(20)】
		/// </summary>
		[DataMember(Order = 24)]
		public string BankCode { get; set; }
		/// <summary>
		/// 是否当天第一次提现
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 25)]
		public bool IsFirstCashOfDay { get; set; }
		/// <summary>
		/// 扩展数据
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 26)]
		public string Meta { get; set; }
		/// <summary>
		/// 状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 27)]
		public int Status { get; set; }
		/// <summary>
		/// 充值用户ip
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 28)]
		public string UserIP { get; set; }
		/// <summary>
		/// 我方传给银行的订单号（transaction_id）对账使用!
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 29)]
		public string OwnOrderId { get; set; }
		/// <summary>
		/// 传给银行的交易金额
		/// 【字段 decimal(15,6)】
		/// </summary>
		[DataMember(Order = 30)]
		public decimal TransMoney { get; set; }
		/// <summary>
		/// 订单对账金额（单位元）
		/// 【字段 decimal(15,6)】
		/// </summary>
		[DataMember(Order = 31)]
		public decimal OrderMoney { get; set; }
		/// <summary>
		/// 银行返回时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 32)]
		public DateTime? BankResponseTime { get; set; }
		/// <summary>
		/// 银行订单编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 33)]
		public string BankOrderId { get; set; }
		/// <summary>
		/// 银行回调时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 34)]
		public DateTime? BankCallbackTime { get; set; }
		/// <summary>
		/// 银行订单的成功时间（对账使用）
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 35)]
		public DateTime? BankTime { get; set; }
		/// <summary>
		/// 支付条形码
		/// 【字段 varchar(500)】
		/// </summary>
		[DataMember(Order = 36)]
		public string BrCode { get; set; }
		/// <summary>
		/// 支付二维码
		/// 【字段 varchar(2000)】
		/// </summary>
		[DataMember(Order = 37)]
		public string QrCode { get; set; }
		/// <summary>
		/// 实际数量（正负数）
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 38)]
		public long Amount { get; set; }
		/// <summary>
		/// 我方承担的手续费
		/// 【字段 decimal(10,3)】
		/// </summary>
		[DataMember(Order = 39)]
		public decimal OwnFee { get; set; }
		/// <summary>
		/// 用户承担的手续费
		/// 【字段 decimal(10,3)】
		/// </summary>
		[DataMember(Order = 40)]
		public decimal UserFee { get; set; }
		/// <summary>
		/// 支付金额（提款金额）
		/// 【字段 decimal(10,2)】
		/// </summary>
		[DataMember(Order = 41)]
		public decimal UserMoney { get; set; }
		/// <summary>
		/// 处理后余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 42)]
		public long EndBalance { get; set; }
		/// <summary>
		/// bonus实际变化数量（正负数）
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 43)]
		public long AmountBonus { get; set; }
		/// <summary>
		/// 处理后bonus余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 44)]
		public long EndBonus { get; set; }
		/// <summary>
		/// 结算表名
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 45)]
		public string SettlTable { get; set; }
		/// <summary>
		/// 结算编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 46)]
		public string SettlId { get; set; }
		/// <summary>
		/// 结算金额(正负数)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 47)]
		public long SettlAmount { get; set; }
		/// <summary>
		/// 结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 48)]
		public int SettlStatus { get; set; }
		/// <summary>
		/// 完成标记0.三方回调完成 1.我方主动调用
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 49)]
		public int CompleteFlag { get; set; }
		/// <summary>
		/// 活动id集合|分割
		/// 【字段 varchar(2000)】
		/// </summary>
		[DataMember(Order = 50)]
		public string ActivityIds { get; set; }
		/// <summary>
		/// 充值是否添加账户余额
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 51)]
		public bool IsAddBalance { get; set; }
		/// <summary>
		/// 是否提现审核订单
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 52)]
		public bool IsAuditOrder { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 53)]
		public string CountryID { get; set; }
		/// <summary>
		/// 我方收取的vip用户手续费
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 54)]
		public long UserFeeAmount { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_bank_orderEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_bank_orderEO MapDataReader(IDataReader reader)
		{
		    Sb_bank_orderEO ret = new Sb_bank_orderEO();
			ret.OrderID = reader.ToString("OrderID");
			ret.OriginalOrderID = ret.OrderID;
			ret.ProviderID = reader.ToString("ProviderID");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.UserID = reader.ToString("UserID");
			ret.FromMode = reader.ToInt32("FromMode");
			ret.FromId = reader.ToString("FromId");
			ret.DomainID = reader.ToString("DomainID");
			ret.UserKind = reader.ToInt32("UserKind");
			ret.RegistDate = reader.ToDateTimeN("RegistDate");
			ret.OrderType = reader.ToInt32("OrderType");
			ret.BankID = reader.ToString("BankID");
			ret.PaytypeID = reader.ToInt32("PaytypeID");
			ret.PaytypeChannel = reader.ToInt32("PaytypeChannel");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.PlanAmount = reader.ToInt64("PlanAmount");
			ret.AppRequestUUID = reader.ToString("AppRequestUUID");
			ret.AppOrderId = reader.ToString("AppOrderId");
			ret.AppReqComment = reader.ToString("AppReqComment");
			ret.AppRequestTime = reader.ToDateTime("AppRequestTime");
			ret.AccName = reader.ToString("AccName");
			ret.AccNumber = reader.ToString("AccNumber");
			ret.BankCode = reader.ToString("BankCode");
			ret.IsFirstCashOfDay = reader.ToBoolean("IsFirstCashOfDay");
			ret.Meta = reader.ToString("Meta");
			ret.Status = reader.ToInt32("Status");
			ret.UserIP = reader.ToString("UserIP");
			ret.OwnOrderId = reader.ToString("OwnOrderId");
			ret.TransMoney = reader.ToDecimal("TransMoney");
			ret.OrderMoney = reader.ToDecimal("OrderMoney");
			ret.BankResponseTime = reader.ToDateTimeN("BankResponseTime");
			ret.BankOrderId = reader.ToString("BankOrderId");
			ret.BankCallbackTime = reader.ToDateTimeN("BankCallbackTime");
			ret.BankTime = reader.ToDateTimeN("BankTime");
			ret.BrCode = reader.ToString("BrCode");
			ret.QrCode = reader.ToString("QrCode");
			ret.Amount = reader.ToInt64("Amount");
			ret.OwnFee = reader.ToDecimal("OwnFee");
			ret.UserFee = reader.ToDecimal("UserFee");
			ret.UserMoney = reader.ToDecimal("UserMoney");
			ret.EndBalance = reader.ToInt64("EndBalance");
			ret.AmountBonus = reader.ToInt64("AmountBonus");
			ret.EndBonus = reader.ToInt64("EndBonus");
			ret.SettlTable = reader.ToString("SettlTable");
			ret.SettlId = reader.ToString("SettlId");
			ret.SettlAmount = reader.ToInt64("SettlAmount");
			ret.SettlStatus = reader.ToInt32("SettlStatus");
			ret.CompleteFlag = reader.ToInt32("CompleteFlag");
			ret.ActivityIds = reader.ToString("ActivityIds");
			ret.IsAddBalance = reader.ToBoolean("IsAddBalance");
			ret.IsAuditOrder = reader.ToBoolean("IsAuditOrder");
			ret.CountryID = reader.ToString("CountryID");
			ret.UserFeeAmount = reader.ToInt64("UserFeeAmount");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 银行订单表
	/// 【表 sb_bank_order 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_bank_orderMO : MySqlTableMO<Sb_bank_orderEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_bank_order`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_bank_orderMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_bank_orderMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_bank_orderMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_bank_orderEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_bank_orderEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_bank_orderEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OrderID`, `ProviderID`, `AppID`, `OperatorID`, `UserID`, `FromMode`, `FromId`, `DomainID`, `UserKind`, `RegistDate`, `OrderType`, `BankID`, `PaytypeID`, `PaytypeChannel`, `CurrencyID`, `RecDate`, `PlanAmount`, `AppRequestUUID`, `AppOrderId`, `AppReqComment`, `AppRequestTime`, `AccName`, `AccNumber`, `BankCode`, `IsFirstCashOfDay`, `Meta`, `Status`, `UserIP`, `OwnOrderId`, `TransMoney`, `OrderMoney`, `BankResponseTime`, `BankOrderId`, `BankCallbackTime`, `BankTime`, `BrCode`, `QrCode`, `Amount`, `OwnFee`, `UserFee`, `UserMoney`, `EndBalance`, `AmountBonus`, `EndBonus`, `SettlTable`, `SettlId`, `SettlAmount`, `SettlStatus`, `CompleteFlag`, `ActivityIds`, `IsAddBalance`, `IsAuditOrder`, `CountryID`, `UserFeeAmount`) VALUE (@OrderID, @ProviderID, @AppID, @OperatorID, @UserID, @FromMode, @FromId, @DomainID, @UserKind, @RegistDate, @OrderType, @BankID, @PaytypeID, @PaytypeChannel, @CurrencyID, @RecDate, @PlanAmount, @AppRequestUUID, @AppOrderId, @AppReqComment, @AppRequestTime, @AccName, @AccNumber, @BankCode, @IsFirstCashOfDay, @Meta, @Status, @UserIP, @OwnOrderId, @TransMoney, @OrderMoney, @BankResponseTime, @BankOrderId, @BankCallbackTime, @BankTime, @BrCode, @QrCode, @Amount, @OwnFee, @UserFee, @UserMoney, @EndBalance, @AmountBonus, @EndBonus, @SettlTable, @SettlId, @SettlAmount, @SettlStatus, @CompleteFlag, @ActivityIds, @IsAddBalance, @IsAuditOrder, @CountryID, @UserFeeAmount);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", item.OrderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID != null ? item.ProviderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@DomainID", item.DomainID != null ? item.DomainID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@RegistDate", item.RegistDate.HasValue ? item.RegistDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderType", item.OrderType, MySqlDbType.Int32),
				Database.CreateInParameter("@BankID", item.BankID != null ? item.BankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PaytypeID", item.PaytypeID, MySqlDbType.Int32),
				Database.CreateInParameter("@PaytypeChannel", item.PaytypeChannel, MySqlDbType.Int32),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@PlanAmount", item.PlanAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@AppRequestUUID", item.AppRequestUUID != null ? item.AppRequestUUID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppOrderId", item.AppOrderId != null ? item.AppOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppReqComment", item.AppReqComment != null ? item.AppReqComment : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppRequestTime", item.AppRequestTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@AccName", item.AccName != null ? item.AccName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccNumber", item.AccNumber != null ? item.AccNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsFirstCashOfDay", item.IsFirstCashOfDay, MySqlDbType.Byte),
				Database.CreateInParameter("@Meta", item.Meta != null ? item.Meta : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@UserIP", item.UserIP != null ? item.UserIP : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OwnOrderId", item.OwnOrderId != null ? item.OwnOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@TransMoney", item.TransMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderMoney", item.OrderMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@BankResponseTime", item.BankResponseTime.HasValue ? item.BankResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankOrderId", item.BankOrderId != null ? item.BankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCallbackTime", item.BankCallbackTime.HasValue ? item.BankCallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankTime", item.BankTime.HasValue ? item.BankTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BrCode", item.BrCode != null ? item.BrCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QrCode", item.QrCode != null ? item.QrCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@OwnFee", item.OwnFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserFee", item.UserFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserMoney", item.UserMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@EndBalance", item.EndBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@AmountBonus", item.AmountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonus", item.EndBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@SettlTable", item.SettlTable != null ? item.SettlTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SettlId", item.SettlId != null ? item.SettlId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SettlAmount", item.SettlAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@SettlStatus", item.SettlStatus, MySqlDbType.Int32),
				Database.CreateInParameter("@CompleteFlag", item.CompleteFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@ActivityIds", item.ActivityIds != null ? item.ActivityIds : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsAddBalance", item.IsAddBalance, MySqlDbType.Byte),
				Database.CreateInParameter("@IsAuditOrder", item.IsAuditOrder, MySqlDbType.Byte),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserFeeAmount", item.UserFeeAmount, MySqlDbType.Int64),
			};
		}
		public int AddByBatch(IEnumerable<Sb_bank_orderEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_bank_orderEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_bank_orderEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OrderID`, `ProviderID`, `AppID`, `OperatorID`, `UserID`, `FromMode`, `FromId`, `DomainID`, `UserKind`, `RegistDate`, `OrderType`, `BankID`, `PaytypeID`, `PaytypeChannel`, `CurrencyID`, `RecDate`, `PlanAmount`, `AppRequestUUID`, `AppOrderId`, `AppReqComment`, `AppRequestTime`, `AccName`, `AccNumber`, `BankCode`, `IsFirstCashOfDay`, `Meta`, `Status`, `UserIP`, `OwnOrderId`, `TransMoney`, `OrderMoney`, `BankResponseTime`, `BankOrderId`, `BankCallbackTime`, `BankTime`, `BrCode`, `QrCode`, `Amount`, `OwnFee`, `UserFee`, `UserMoney`, `EndBalance`, `AmountBonus`, `EndBonus`, `SettlTable`, `SettlId`, `SettlAmount`, `SettlStatus`, `CompleteFlag`, `ActivityIds`, `IsAddBalance`, `IsAuditOrder`, `CountryID`, `UserFeeAmount`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OrderID}','{item.ProviderID}','{item.AppID}','{item.OperatorID}','{item.UserID}',{item.FromMode},'{item.FromId}','{item.DomainID}',{item.UserKind},'{item.RegistDate?.ToString("yyyy-MM-dd HH:mm:ss")}',{item.OrderType},'{item.BankID}',{item.PaytypeID},{item.PaytypeChannel},'{item.CurrencyID}','{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.PlanAmount},'{item.AppRequestUUID}','{item.AppOrderId}','{item.AppReqComment}','{item.AppRequestTime.ToString("yyyy-MM-dd HH:mm:ss")}','{item.AccName}','{item.AccNumber}','{item.BankCode}',{item.IsFirstCashOfDay},'{item.Meta}',{item.Status},'{item.UserIP}','{item.OwnOrderId}',{item.TransMoney},{item.OrderMoney},'{item.BankResponseTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.BankOrderId}','{item.BankCallbackTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.BankTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.BrCode}','{item.QrCode}',{item.Amount},{item.OwnFee},{item.UserFee},{item.UserMoney},{item.EndBalance},{item.AmountBonus},{item.EndBonus},'{item.SettlTable}','{item.SettlId}',{item.SettlAmount},{item.SettlStatus},{item.CompleteFlag},'{item.ActivityIds}',{item.IsAddBalance},{item.IsAuditOrder},'{item.CountryID}',{item.UserFeeAmount}),");
				if (count == batchCount)
				{
					count = 0;
					sql.Insert(0, insertSql);
					var ret = sql.ToString().TrimEnd(',');
					sql.Clear();
	                yield return ret;
				}
			}
			if (sql.Length > 0)
			{
	            sql.Insert(0, insertSql);
	            yield return sql.ToString().TrimEnd(',');
	        }
	    }
	    #endregion // Add
	    
		#region Remove
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string orderID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(orderID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(orderID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string orderID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_bank_orderEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OrderID, tm_);
		}
		public async Task<int> RemoveAsync(Sb_bank_orderEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.OrderID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByProviderID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByProviderID(string providerID, TransactionManager tm_ = null)
		{
			RepairRemoveByProviderIDData(providerID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByProviderIDAsync(string providerID, TransactionManager tm_ = null)
		{
			RepairRemoveByProviderIDData(providerID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByProviderIDData(string providerID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (providerID != null ? "`ProviderID` = @ProviderID" : "`ProviderID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (providerID != null)
				paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByProviderID
		#region RemoveByAppID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppID(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppIDData(string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppID
		#region RemoveByOperatorID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperatorID(string operatorID, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOperatorIDData(string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOperatorID
		#region RemoveByUserID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserID(string userID, TransactionManager tm_ = null)
		{
			RepairRemoveByUserIDData(userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserIDAsync(string userID, TransactionManager tm_ = null)
		{
			RepairRemoveByUserIDData(userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserIDData(string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByUserID
		#region RemoveByFromMode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFromMode(int fromMode, TransactionManager tm_ = null)
		{
			RepairRemoveByFromModeData(fromMode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFromModeAsync(int fromMode, TransactionManager tm_ = null)
		{
			RepairRemoveByFromModeData(fromMode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFromModeData(int fromMode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `FromMode` = @FromMode";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
		}
		#endregion // RemoveByFromMode
		#region RemoveByFromId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFromId(string fromId, TransactionManager tm_ = null)
		{
			RepairRemoveByFromIdData(fromId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFromIdAsync(string fromId, TransactionManager tm_ = null)
		{
			RepairRemoveByFromIdData(fromId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFromIdData(string fromId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByFromId
		#region RemoveByDomainID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDomainID(string domainID, TransactionManager tm_ = null)
		{
			RepairRemoveByDomainIDData(domainID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByDomainIDAsync(string domainID, TransactionManager tm_ = null)
		{
			RepairRemoveByDomainIDData(domainID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByDomainIDData(string domainID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (domainID != null ? "`DomainID` = @DomainID" : "`DomainID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (domainID != null)
				paras_.Add(Database.CreateInParameter("@DomainID", domainID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByDomainID
		#region RemoveByUserKind
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserKind(int userKind, TransactionManager tm_ = null)
		{
			RepairRemoveByUserKindData(userKind, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserKindAsync(int userKind, TransactionManager tm_ = null)
		{
			RepairRemoveByUserKindData(userKind, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserKindData(int userKind, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserKind` = @UserKind";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
		}
		#endregion // RemoveByUserKind
		#region RemoveByRegistDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRegistDate(DateTime? registDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRegistDateData(registDate.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRegistDateAsync(DateTime? registDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRegistDateData(registDate.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRegistDateData(DateTime? registDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (registDate.HasValue ? "`RegistDate` = @RegistDate" : "`RegistDate` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (registDate.HasValue)
				paras_.Add(Database.CreateInParameter("@RegistDate", registDate.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByRegistDate
		#region RemoveByOrderType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderType(int orderType, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderTypeData(orderType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderTypeAsync(int orderType, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderTypeData(orderType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderTypeData(int orderType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderType` = @OrderType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32));
		}
		#endregion // RemoveByOrderType
		#region RemoveByBankID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankID(string bankID, TransactionManager tm_ = null)
		{
			RepairRemoveByBankIDData(bankID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankIDAsync(string bankID, TransactionManager tm_ = null)
		{
			RepairRemoveByBankIDData(bankID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankIDData(string bankID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankID != null ? "`BankID` = @BankID" : "`BankID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankID != null)
				paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBankID
		#region RemoveByPaytypeID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPaytypeID(int paytypeID, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeIDData(paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPaytypeIDAsync(int paytypeID, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeIDData(paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPaytypeIDData(int paytypeID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PaytypeID` = @PaytypeID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32));
		}
		#endregion // RemoveByPaytypeID
		#region RemoveByPaytypeChannel
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPaytypeChannel(int paytypeChannel, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeChannelData(paytypeChannel, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPaytypeChannelAsync(int paytypeChannel, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeChannelData(paytypeChannel, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPaytypeChannelData(int paytypeChannel, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PaytypeChannel` = @PaytypeChannel";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32));
		}
		#endregion // RemoveByPaytypeChannel
		#region RemoveByCurrencyID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCurrencyIDData(string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCurrencyID
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRecDateData(DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RecDate` = @RecDate";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
		}
		#endregion // RemoveByRecDate
		#region RemoveByPlanAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPlanAmount(long planAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPlanAmountData(planAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPlanAmountAsync(long planAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPlanAmountData(planAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPlanAmountData(long planAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PlanAmount` = @PlanAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByPlanAmount
		#region RemoveByAppRequestUUID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppRequestUUID(string appRequestUUID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppRequestUUIDData(appRequestUUID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppRequestUUIDAsync(string appRequestUUID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppRequestUUIDData(appRequestUUID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppRequestUUIDData(string appRequestUUID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (appRequestUUID != null ? "`AppRequestUUID` = @AppRequestUUID" : "`AppRequestUUID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (appRequestUUID != null)
				paras_.Add(Database.CreateInParameter("@AppRequestUUID", appRequestUUID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppRequestUUID
		#region RemoveByAppOrderId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppOrderId(string appOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByAppOrderIdData(appOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppOrderIdAsync(string appOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByAppOrderIdData(appOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppOrderIdData(string appOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (appOrderId != null ? "`AppOrderId` = @AppOrderId" : "`AppOrderId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (appOrderId != null)
				paras_.Add(Database.CreateInParameter("@AppOrderId", appOrderId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppOrderId
		#region RemoveByAppReqComment
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppReqComment(string appReqComment, TransactionManager tm_ = null)
		{
			RepairRemoveByAppReqCommentData(appReqComment, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppReqCommentAsync(string appReqComment, TransactionManager tm_ = null)
		{
			RepairRemoveByAppReqCommentData(appReqComment, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppReqCommentData(string appReqComment, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (appReqComment != null ? "`AppReqComment` = @AppReqComment" : "`AppReqComment` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (appReqComment != null)
				paras_.Add(Database.CreateInParameter("@AppReqComment", appReqComment, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppReqComment
		#region RemoveByAppRequestTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppRequestTime(DateTime appRequestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByAppRequestTimeData(appRequestTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppRequestTimeAsync(DateTime appRequestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByAppRequestTimeData(appRequestTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppRequestTimeData(DateTime appRequestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AppRequestTime` = @AppRequestTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime));
		}
		#endregion // RemoveByAppRequestTime
		#region RemoveByAccName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAccName(string accName, TransactionManager tm_ = null)
		{
			RepairRemoveByAccNameData(accName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAccNameAsync(string accName, TransactionManager tm_ = null)
		{
			RepairRemoveByAccNameData(accName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAccNameData(string accName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (accName != null ? "`AccName` = @AccName" : "`AccName` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (accName != null)
				paras_.Add(Database.CreateInParameter("@AccName", accName, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAccName
		#region RemoveByAccNumber
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAccNumber(string accNumber, TransactionManager tm_ = null)
		{
			RepairRemoveByAccNumberData(accNumber, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAccNumberAsync(string accNumber, TransactionManager tm_ = null)
		{
			RepairRemoveByAccNumberData(accNumber, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAccNumberData(string accNumber, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (accNumber != null ? "`AccNumber` = @AccNumber" : "`AccNumber` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (accNumber != null)
				paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAccNumber
		#region RemoveByBankCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankCode(string bankCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBankCodeData(bankCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankCodeAsync(string bankCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBankCodeData(bankCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankCodeData(string bankCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankCode != null)
				paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBankCode
		#region RemoveByIsFirstCashOfDay
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsFirstCashOfDay(bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			RepairRemoveByIsFirstCashOfDayData(isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsFirstCashOfDayAsync(bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			RepairRemoveByIsFirstCashOfDayData(isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsFirstCashOfDayData(bool isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsFirstCashOfDay` = @IsFirstCashOfDay";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsFirstCashOfDay
		#region RemoveByMeta
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByMeta(string meta, TransactionManager tm_ = null)
		{
			RepairRemoveByMetaData(meta, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByMetaAsync(string meta, TransactionManager tm_ = null)
		{
			RepairRemoveByMetaData(meta, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByMetaData(string meta, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (meta != null ? "`Meta` = @Meta" : "`Meta` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (meta != null)
				paras_.Add(Database.CreateInParameter("@Meta", meta, MySqlDbType.Text));
		}
		#endregion // RemoveByMeta
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByStatus(int status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByStatusAsync(int status, TransactionManager tm_ = null)
		{
			RepairRemoveByStatusData(status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByStatusData(int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Status` = @Status";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
		}
		#endregion // RemoveByStatus
		#region RemoveByUserIP
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserIP(string userIP, TransactionManager tm_ = null)
		{
			RepairRemoveByUserIPData(userIP, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserIPAsync(string userIP, TransactionManager tm_ = null)
		{
			RepairRemoveByUserIPData(userIP, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserIPData(string userIP, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (userIP != null ? "`UserIP` = @UserIP" : "`UserIP` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (userIP != null)
				paras_.Add(Database.CreateInParameter("@UserIP", userIP, MySqlDbType.VarChar));
		}
		#endregion // RemoveByUserIP
		#region RemoveByOwnOrderId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOwnOrderId(string ownOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnOrderIdData(ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOwnOrderIdAsync(string ownOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnOrderIdData(ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOwnOrderIdData(string ownOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOwnOrderId
		#region RemoveByTransMoney
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTransMoney(decimal transMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByTransMoneyData(transMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTransMoneyAsync(decimal transMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByTransMoneyData(transMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTransMoneyData(decimal transMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TransMoney` = @TransMoney";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByTransMoney
		#region RemoveByOrderMoney
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderMoney(decimal orderMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderMoneyData(orderMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderMoneyAsync(decimal orderMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderMoneyData(orderMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderMoneyData(decimal orderMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderMoney` = @OrderMoney";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByOrderMoney
		#region RemoveByBankResponseTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankResponseTime(DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankResponseTimeData(bankResponseTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankResponseTimeAsync(DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankResponseTimeData(bankResponseTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankResponseTimeData(DateTime? bankResponseTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankResponseTime.HasValue ? "`BankResponseTime` = @BankResponseTime" : "`BankResponseTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankResponseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankResponseTime", bankResponseTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByBankResponseTime
		#region RemoveByBankOrderId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankOrderId(string bankOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByBankOrderIdData(bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankOrderIdAsync(string bankOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByBankOrderIdData(bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankOrderIdData(string bankOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankOrderId != null ? "`BankOrderId` = @BankOrderId" : "`BankOrderId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankOrderId != null)
				paras_.Add(Database.CreateInParameter("@BankOrderId", bankOrderId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBankOrderId
		#region RemoveByBankCallbackTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankCallbackTime(DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankCallbackTimeData(bankCallbackTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankCallbackTimeAsync(DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankCallbackTimeData(bankCallbackTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankCallbackTimeData(DateTime? bankCallbackTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankCallbackTime.HasValue ? "`BankCallbackTime` = @BankCallbackTime" : "`BankCallbackTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankCallbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByBankCallbackTime
		#region RemoveByBankTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankTime(DateTime? bankTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankTimeData(bankTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankTimeAsync(DateTime? bankTime, TransactionManager tm_ = null)
		{
			RepairRemoveByBankTimeData(bankTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankTimeData(DateTime? bankTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankTime.HasValue ? "`BankTime` = @BankTime" : "`BankTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankTime", bankTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByBankTime
		#region RemoveByBrCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBrCode(string brCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBrCodeData(brCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBrCodeAsync(string brCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBrCodeData(brCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBrCodeData(string brCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (brCode != null ? "`BrCode` = @BrCode" : "`BrCode` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (brCode != null)
				paras_.Add(Database.CreateInParameter("@BrCode", brCode, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBrCode
		#region RemoveByQrCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByQrCode(string qrCode, TransactionManager tm_ = null)
		{
			RepairRemoveByQrCodeData(qrCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByQrCodeAsync(string qrCode, TransactionManager tm_ = null)
		{
			RepairRemoveByQrCodeData(qrCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByQrCodeData(string qrCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (qrCode != null ? "`QrCode` = @QrCode" : "`QrCode` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (qrCode != null)
				paras_.Add(Database.CreateInParameter("@QrCode", qrCode, MySqlDbType.VarChar));
		}
		#endregion // RemoveByQrCode
		#region RemoveByAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAmount(long amount, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountData(amount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAmountAsync(long amount, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountData(amount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAmountData(long amount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Amount` = @Amount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
		}
		#endregion // RemoveByAmount
		#region RemoveByOwnFee
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOwnFee(decimal ownFee, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnFeeData(ownFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOwnFeeAsync(decimal ownFee, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnFeeData(ownFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOwnFeeData(decimal ownFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OwnFee` = @OwnFee";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByOwnFee
		#region RemoveByUserFee
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserFee(decimal userFee, TransactionManager tm_ = null)
		{
			RepairRemoveByUserFeeData(userFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserFeeAsync(decimal userFee, TransactionManager tm_ = null)
		{
			RepairRemoveByUserFeeData(userFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserFeeData(decimal userFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserFee` = @UserFee";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByUserFee
		#region RemoveByUserMoney
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserMoney(decimal userMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByUserMoneyData(userMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserMoneyAsync(decimal userMoney, TransactionManager tm_ = null)
		{
			RepairRemoveByUserMoneyData(userMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserMoneyData(decimal userMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserMoney` = @UserMoney";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByUserMoney
		#region RemoveByEndBalance
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByEndBalance(long endBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBalanceData(endBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByEndBalanceAsync(long endBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBalanceData(endBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByEndBalanceData(long endBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `EndBalance` = @EndBalance";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64));
		}
		#endregion // RemoveByEndBalance
		#region RemoveByAmountBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAmountBonus(long amountBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountBonusData(amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAmountBonusAsync(long amountBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountBonusData(amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAmountBonusData(long amountBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AmountBonus` = @AmountBonus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64));
		}
		#endregion // RemoveByAmountBonus
		#region RemoveByEndBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByEndBonus(long endBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBonusData(endBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByEndBonusAsync(long endBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBonusData(endBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByEndBonusData(long endBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `EndBonus` = @EndBonus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64));
		}
		#endregion // RemoveByEndBonus
		#region RemoveBySettlTable
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySettlTable(string settlTable, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlTableData(settlTable, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySettlTableAsync(string settlTable, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlTableData(settlTable, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySettlTableData(string settlTable, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (settlTable != null ? "`SettlTable` = @SettlTable" : "`SettlTable` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (settlTable != null)
				paras_.Add(Database.CreateInParameter("@SettlTable", settlTable, MySqlDbType.VarChar));
		}
		#endregion // RemoveBySettlTable
		#region RemoveBySettlId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySettlId(string settlId, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlIdData(settlId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySettlIdAsync(string settlId, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlIdData(settlId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySettlIdData(string settlId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (settlId != null ? "`SettlId` = @SettlId" : "`SettlId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (settlId != null)
				paras_.Add(Database.CreateInParameter("@SettlId", settlId, MySqlDbType.VarChar));
		}
		#endregion // RemoveBySettlId
		#region RemoveBySettlAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySettlAmount(long settlAmount, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlAmountData(settlAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySettlAmountAsync(long settlAmount, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlAmountData(settlAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySettlAmountData(long settlAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `SettlAmount` = @SettlAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveBySettlAmount
		#region RemoveBySettlStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySettlStatus(int settlStatus, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlStatusData(settlStatus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySettlStatusAsync(int settlStatus, TransactionManager tm_ = null)
		{
			RepairRemoveBySettlStatusData(settlStatus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySettlStatusData(int settlStatus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `SettlStatus` = @SettlStatus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32));
		}
		#endregion // RemoveBySettlStatus
		#region RemoveByCompleteFlag
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCompleteFlag(int completeFlag, TransactionManager tm_ = null)
		{
			RepairRemoveByCompleteFlagData(completeFlag, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCompleteFlagAsync(int completeFlag, TransactionManager tm_ = null)
		{
			RepairRemoveByCompleteFlagData(completeFlag, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCompleteFlagData(int completeFlag, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CompleteFlag` = @CompleteFlag";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32));
		}
		#endregion // RemoveByCompleteFlag
		#region RemoveByActivityIds
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByActivityIds(string activityIds, TransactionManager tm_ = null)
		{
			RepairRemoveByActivityIdsData(activityIds, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByActivityIdsAsync(string activityIds, TransactionManager tm_ = null)
		{
			RepairRemoveByActivityIdsData(activityIds, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByActivityIdsData(string activityIds, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (activityIds != null ? "`ActivityIds` = @ActivityIds" : "`ActivityIds` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (activityIds != null)
				paras_.Add(Database.CreateInParameter("@ActivityIds", activityIds, MySqlDbType.VarChar));
		}
		#endregion // RemoveByActivityIds
		#region RemoveByIsAddBalance
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsAddBalance(bool isAddBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAddBalanceData(isAddBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsAddBalanceAsync(bool isAddBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAddBalanceData(isAddBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsAddBalanceData(bool isAddBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsAddBalance` = @IsAddBalance";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsAddBalance
		#region RemoveByIsAuditOrder
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsAuditOrder(bool isAuditOrder, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditOrderData(isAuditOrder, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsAuditOrderAsync(bool isAuditOrder, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditOrderData(isAuditOrder, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsAuditOrderData(bool isAuditOrder, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsAuditOrder` = @IsAuditOrder";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsAuditOrder
		#region RemoveByCountryID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCountryID(string countryID, TransactionManager tm_ = null)
		{
			RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCountryIDData(string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCountryID
		#region RemoveByUserFeeAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUserFeeAmount(long userFeeAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByUserFeeAmountData(userFeeAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUserFeeAmountAsync(long userFeeAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByUserFeeAmountData(userFeeAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUserFeeAmountData(long userFeeAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserFeeAmount` = @UserFeeAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByUserFeeAmount
		#endregion // RemoveByXXX
	    
		#region RemoveByFKOrUnique
		#endregion // RemoveByFKOrUnique
		#endregion //Remove
	    
		#region Put
		#region PutItem
		/// <summary>
		/// 更新实体到数据库
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(Sb_bank_orderEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_bank_orderEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_bank_orderEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderID` = @OrderID, `ProviderID` = @ProviderID, `AppID` = @AppID, `OperatorID` = @OperatorID, `UserID` = @UserID, `FromMode` = @FromMode, `FromId` = @FromId, `DomainID` = @DomainID, `UserKind` = @UserKind, `RegistDate` = @RegistDate, `OrderType` = @OrderType, `BankID` = @BankID, `PaytypeID` = @PaytypeID, `PaytypeChannel` = @PaytypeChannel, `CurrencyID` = @CurrencyID, `PlanAmount` = @PlanAmount, `AppRequestUUID` = @AppRequestUUID, `AppOrderId` = @AppOrderId, `AppReqComment` = @AppReqComment, `AccName` = @AccName, `AccNumber` = @AccNumber, `BankCode` = @BankCode, `IsFirstCashOfDay` = @IsFirstCashOfDay, `Meta` = @Meta, `Status` = @Status, `UserIP` = @UserIP, `OwnOrderId` = @OwnOrderId, `TransMoney` = @TransMoney, `OrderMoney` = @OrderMoney, `BankResponseTime` = @BankResponseTime, `BankOrderId` = @BankOrderId, `BankCallbackTime` = @BankCallbackTime, `BankTime` = @BankTime, `BrCode` = @BrCode, `QrCode` = @QrCode, `Amount` = @Amount, `OwnFee` = @OwnFee, `UserFee` = @UserFee, `UserMoney` = @UserMoney, `EndBalance` = @EndBalance, `AmountBonus` = @AmountBonus, `EndBonus` = @EndBonus, `SettlTable` = @SettlTable, `SettlId` = @SettlId, `SettlAmount` = @SettlAmount, `SettlStatus` = @SettlStatus, `CompleteFlag` = @CompleteFlag, `ActivityIds` = @ActivityIds, `IsAddBalance` = @IsAddBalance, `IsAuditOrder` = @IsAuditOrder, `CountryID` = @CountryID, `UserFeeAmount` = @UserFeeAmount WHERE `OrderID` = @OrderID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", item.OrderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID != null ? item.ProviderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@DomainID", item.DomainID != null ? item.DomainID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@RegistDate", item.RegistDate.HasValue ? item.RegistDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderType", item.OrderType, MySqlDbType.Int32),
				Database.CreateInParameter("@BankID", item.BankID != null ? item.BankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PaytypeID", item.PaytypeID, MySqlDbType.Int32),
				Database.CreateInParameter("@PaytypeChannel", item.PaytypeChannel, MySqlDbType.Int32),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PlanAmount", item.PlanAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@AppRequestUUID", item.AppRequestUUID != null ? item.AppRequestUUID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppOrderId", item.AppOrderId != null ? item.AppOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppReqComment", item.AppReqComment != null ? item.AppReqComment : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccName", item.AccName != null ? item.AccName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccNumber", item.AccNumber != null ? item.AccNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsFirstCashOfDay", item.IsFirstCashOfDay, MySqlDbType.Byte),
				Database.CreateInParameter("@Meta", item.Meta != null ? item.Meta : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@UserIP", item.UserIP != null ? item.UserIP : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OwnOrderId", item.OwnOrderId != null ? item.OwnOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@TransMoney", item.TransMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderMoney", item.OrderMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@BankResponseTime", item.BankResponseTime.HasValue ? item.BankResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankOrderId", item.BankOrderId != null ? item.BankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCallbackTime", item.BankCallbackTime.HasValue ? item.BankCallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankTime", item.BankTime.HasValue ? item.BankTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@BrCode", item.BrCode != null ? item.BrCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@QrCode", item.QrCode != null ? item.QrCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@OwnFee", item.OwnFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserFee", item.UserFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@UserMoney", item.UserMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@EndBalance", item.EndBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@AmountBonus", item.AmountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonus", item.EndBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@SettlTable", item.SettlTable != null ? item.SettlTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SettlId", item.SettlId != null ? item.SettlId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SettlAmount", item.SettlAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@SettlStatus", item.SettlStatus, MySqlDbType.Int32),
				Database.CreateInParameter("@CompleteFlag", item.CompleteFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@ActivityIds", item.ActivityIds != null ? item.ActivityIds : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsAddBalance", item.IsAddBalance, MySqlDbType.Byte),
				Database.CreateInParameter("@IsAuditOrder", item.IsAuditOrder, MySqlDbType.Byte),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserFeeAmount", item.UserFeeAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID_Original", item.HasOriginal ? item.OriginalOrderID : item.OrderID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_bank_orderEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_bank_orderEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += await PutAsync(item, tm_);
			}
			return ret;
		}
		#endregion // PutItem
		
		#region PutByPK
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string orderID, string set_, params object[] values_)
		{
			return Put(set_, "`OrderID` = @OrderID", ConcatValues(values_, orderID));
		}
		public async Task<int> PutByPKAsync(string orderID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`OrderID` = @OrderID", ConcatValues(values_, orderID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string orderID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`OrderID` = @OrderID", tm_, ConcatValues(values_, orderID));
		}
		public async Task<int> PutByPKAsync(string orderID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`OrderID` = @OrderID", tm_, ConcatValues(values_, orderID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string orderID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`OrderID` = @OrderID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string orderID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`OrderID` = @OrderID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutProviderID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProviderIDByPK(string orderID, string providerID, TransactionManager tm_ = null)
		{
			RepairPutProviderIDByPKData(orderID, providerID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutProviderIDByPKAsync(string orderID, string providerID, TransactionManager tm_ = null)
		{
			RepairPutProviderIDByPKData(orderID, providerID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutProviderIDByPKData(string orderID, string providerID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ProviderID", providerID != null ? providerID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutProviderID(string providerID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID";
			var parameter_ = Database.CreateInParameter("@ProviderID", providerID != null ? providerID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutProviderIDAsync(string providerID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ProviderID` = @ProviderID";
			var parameter_ = Database.CreateInParameter("@ProviderID", providerID != null ? providerID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutProviderID
		#region PutAppID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppIDByPK(string orderID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(orderID, appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppIDByPKAsync(string orderID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(orderID, appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppIDByPKData(string orderID, string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppID` = @AppID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppID(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppID
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(string orderID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(orderID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(string orderID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(orderID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(string orderID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorID(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorID
		#region PutUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIDByPK(string orderID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(orderID, userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIDByPKAsync(string orderID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(orderID, userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIDByPKData(string orderID, string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserID(string userID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserID` = @UserID";
			var parameter_ = Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserIDAsync(string userID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserID` = @UserID";
			var parameter_ = Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserID
		#region PutFromMode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromModeByPK(string orderID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(orderID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromModeByPKAsync(string orderID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(orderID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromModeByPKData(string orderID, int fromMode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromMode(int fromMode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode";
			var parameter_ = Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFromModeAsync(int fromMode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode";
			var parameter_ = Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFromMode
		#region PutFromId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromIdByPK(string orderID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(orderID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromIdByPKAsync(string orderID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(orderID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromIdByPKData(string orderID, string fromId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromId` = @FromId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromId", fromId != null ? fromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromId(string fromId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FromId` = @FromId";
			var parameter_ = Database.CreateInParameter("@FromId", fromId != null ? fromId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFromIdAsync(string fromId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FromId` = @FromId";
			var parameter_ = Database.CreateInParameter("@FromId", fromId != null ? fromId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFromId
		#region PutDomainID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDomainIDByPK(string orderID, string domainID, TransactionManager tm_ = null)
		{
			RepairPutDomainIDByPKData(orderID, domainID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutDomainIDByPKAsync(string orderID, string domainID, TransactionManager tm_ = null)
		{
			RepairPutDomainIDByPKData(orderID, domainID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutDomainIDByPKData(string orderID, string domainID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DomainID` = @DomainID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DomainID", domainID != null ? domainID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDomainID(string domainID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DomainID` = @DomainID";
			var parameter_ = Database.CreateInParameter("@DomainID", domainID != null ? domainID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutDomainIDAsync(string domainID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DomainID` = @DomainID";
			var parameter_ = Database.CreateInParameter("@DomainID", domainID != null ? domainID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDomainID
		#region PutUserKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserKindByPK(string orderID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(orderID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserKindByPKAsync(string orderID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(orderID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserKindByPKData(string orderID, int userKind, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserKind(int userKind, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind";
			var parameter_ = Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserKindAsync(int userKind, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind";
			var parameter_ = Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserKind
		#region PutRegistDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRegistDateByPK(string orderID, DateTime? registDate, TransactionManager tm_ = null)
		{
			RepairPutRegistDateByPKData(orderID, registDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRegistDateByPKAsync(string orderID, DateTime? registDate, TransactionManager tm_ = null)
		{
			RepairPutRegistDateByPKData(orderID, registDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRegistDateByPKData(string orderID, DateTime? registDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RegistDate` = @RegistDate  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RegistDate", registDate.HasValue ? registDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRegistDate(DateTime? registDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RegistDate` = @RegistDate";
			var parameter_ = Database.CreateInParameter("@RegistDate", registDate.HasValue ? registDate.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRegistDateAsync(DateTime? registDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RegistDate` = @RegistDate";
			var parameter_ = Database.CreateInParameter("@RegistDate", registDate.HasValue ? registDate.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRegistDate
		#region PutOrderType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderTypeByPK(string orderID, int orderType, TransactionManager tm_ = null)
		{
			RepairPutOrderTypeByPKData(orderID, orderType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderTypeByPKAsync(string orderID, int orderType, TransactionManager tm_ = null)
		{
			RepairPutOrderTypeByPKData(orderID, orderType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderTypeByPKData(string orderID, int orderType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderType` = @OrderType  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderType(int orderType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderType` = @OrderType";
			var parameter_ = Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderTypeAsync(int orderType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderType` = @OrderType";
			var parameter_ = Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderType
		#region PutBankID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankIDByPK(string orderID, string bankID, TransactionManager tm_ = null)
		{
			RepairPutBankIDByPKData(orderID, bankID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankIDByPKAsync(string orderID, string bankID, TransactionManager tm_ = null)
		{
			RepairPutBankIDByPKData(orderID, bankID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankIDByPKData(string orderID, string bankID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankID` = @BankID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID != null ? bankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankID(string bankID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankID` = @BankID";
			var parameter_ = Database.CreateInParameter("@BankID", bankID != null ? bankID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankIDAsync(string bankID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankID` = @BankID";
			var parameter_ = Database.CreateInParameter("@BankID", bankID != null ? bankID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankID
		#region PutPaytypeID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytypeIDByPK(string orderID, int paytypeID, TransactionManager tm_ = null)
		{
			RepairPutPaytypeIDByPKData(orderID, paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPaytypeIDByPKAsync(string orderID, int paytypeID, TransactionManager tm_ = null)
		{
			RepairPutPaytypeIDByPKData(orderID, paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPaytypeIDByPKData(string orderID, int paytypeID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PaytypeID` = @PaytypeID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytypeID(int paytypeID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PaytypeID` = @PaytypeID";
			var parameter_ = Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPaytypeIDAsync(int paytypeID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PaytypeID` = @PaytypeID";
			var parameter_ = Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPaytypeID
		#region PutPaytypeChannel
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytypeChannelByPK(string orderID, int paytypeChannel, TransactionManager tm_ = null)
		{
			RepairPutPaytypeChannelByPKData(orderID, paytypeChannel, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPaytypeChannelByPKAsync(string orderID, int paytypeChannel, TransactionManager tm_ = null)
		{
			RepairPutPaytypeChannelByPKData(orderID, paytypeChannel, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPaytypeChannelByPKData(string orderID, int paytypeChannel, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PaytypeChannel` = @PaytypeChannel  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytypeChannel(int paytypeChannel, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PaytypeChannel` = @PaytypeChannel";
			var parameter_ = Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPaytypeChannelAsync(int paytypeChannel, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PaytypeChannel` = @PaytypeChannel";
			var parameter_ = Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPaytypeChannel
		#region PutCurrencyID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(string orderID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(orderID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(string orderID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(orderID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(string orderID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrencyID
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string orderID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(orderID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string orderID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(orderID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string orderID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRecDate
		#region PutPlanAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPlanAmountByPK(string orderID, long planAmount, TransactionManager tm_ = null)
		{
			RepairPutPlanAmountByPKData(orderID, planAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPlanAmountByPKAsync(string orderID, long planAmount, TransactionManager tm_ = null)
		{
			RepairPutPlanAmountByPKData(orderID, planAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPlanAmountByPKData(string orderID, long planAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PlanAmount` = @PlanAmount  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPlanAmount(long planAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PlanAmount` = @PlanAmount";
			var parameter_ = Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPlanAmountAsync(long planAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PlanAmount` = @PlanAmount";
			var parameter_ = Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPlanAmount
		#region PutAppRequestUUID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppRequestUUIDByPK(string orderID, string appRequestUUID, TransactionManager tm_ = null)
		{
			RepairPutAppRequestUUIDByPKData(orderID, appRequestUUID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppRequestUUIDByPKAsync(string orderID, string appRequestUUID, TransactionManager tm_ = null)
		{
			RepairPutAppRequestUUIDByPKData(orderID, appRequestUUID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppRequestUUIDByPKData(string orderID, string appRequestUUID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppRequestUUID` = @AppRequestUUID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppRequestUUID", appRequestUUID != null ? appRequestUUID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppRequestUUID(string appRequestUUID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppRequestUUID` = @AppRequestUUID";
			var parameter_ = Database.CreateInParameter("@AppRequestUUID", appRequestUUID != null ? appRequestUUID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppRequestUUIDAsync(string appRequestUUID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppRequestUUID` = @AppRequestUUID";
			var parameter_ = Database.CreateInParameter("@AppRequestUUID", appRequestUUID != null ? appRequestUUID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppRequestUUID
		#region PutAppOrderId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppOrderIdByPK(string orderID, string appOrderId, TransactionManager tm_ = null)
		{
			RepairPutAppOrderIdByPKData(orderID, appOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppOrderIdByPKAsync(string orderID, string appOrderId, TransactionManager tm_ = null)
		{
			RepairPutAppOrderIdByPKData(orderID, appOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppOrderIdByPKData(string orderID, string appOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppOrderId` = @AppOrderId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppOrderId", appOrderId != null ? appOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppOrderId(string appOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppOrderId` = @AppOrderId";
			var parameter_ = Database.CreateInParameter("@AppOrderId", appOrderId != null ? appOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppOrderIdAsync(string appOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppOrderId` = @AppOrderId";
			var parameter_ = Database.CreateInParameter("@AppOrderId", appOrderId != null ? appOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppOrderId
		#region PutAppReqComment
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppReqCommentByPK(string orderID, string appReqComment, TransactionManager tm_ = null)
		{
			RepairPutAppReqCommentByPKData(orderID, appReqComment, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppReqCommentByPKAsync(string orderID, string appReqComment, TransactionManager tm_ = null)
		{
			RepairPutAppReqCommentByPKData(orderID, appReqComment, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppReqCommentByPKData(string orderID, string appReqComment, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppReqComment` = @AppReqComment  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppReqComment", appReqComment != null ? appReqComment : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppReqComment(string appReqComment, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppReqComment` = @AppReqComment";
			var parameter_ = Database.CreateInParameter("@AppReqComment", appReqComment != null ? appReqComment : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppReqCommentAsync(string appReqComment, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppReqComment` = @AppReqComment";
			var parameter_ = Database.CreateInParameter("@AppReqComment", appReqComment != null ? appReqComment : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppReqComment
		#region PutAppRequestTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppRequestTimeByPK(string orderID, DateTime appRequestTime, TransactionManager tm_ = null)
		{
			RepairPutAppRequestTimeByPKData(orderID, appRequestTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppRequestTimeByPKAsync(string orderID, DateTime appRequestTime, TransactionManager tm_ = null)
		{
			RepairPutAppRequestTimeByPKData(orderID, appRequestTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppRequestTimeByPKData(string orderID, DateTime appRequestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppRequestTime` = @AppRequestTime  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppRequestTime(DateTime appRequestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppRequestTime` = @AppRequestTime";
			var parameter_ = Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppRequestTimeAsync(DateTime appRequestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppRequestTime` = @AppRequestTime";
			var parameter_ = Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppRequestTime
		#region PutAccName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "accName">账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNameByPK(string orderID, string accName, TransactionManager tm_ = null)
		{
			RepairPutAccNameByPKData(orderID, accName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAccNameByPKAsync(string orderID, string accName, TransactionManager tm_ = null)
		{
			RepairPutAccNameByPKData(orderID, accName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAccNameByPKData(string orderID, string accName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AccName` = @AccName  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AccName", accName != null ? accName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccName(string accName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccName` = @AccName";
			var parameter_ = Database.CreateInParameter("@AccName", accName != null ? accName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAccNameAsync(string accName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccName` = @AccName";
			var parameter_ = Database.CreateInParameter("@AccName", accName != null ? accName : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAccName
		#region PutAccNumber
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNumberByPK(string orderID, string accNumber, TransactionManager tm_ = null)
		{
			RepairPutAccNumberByPKData(orderID, accNumber, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAccNumberByPKAsync(string orderID, string accNumber, TransactionManager tm_ = null)
		{
			RepairPutAccNumberByPKData(orderID, accNumber, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAccNumberByPKData(string orderID, string accNumber, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AccNumber", accNumber != null ? accNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNumber(string accNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber";
			var parameter_ = Database.CreateInParameter("@AccNumber", accNumber != null ? accNumber : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAccNumberAsync(string accNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber";
			var parameter_ = Database.CreateInParameter("@AccNumber", accNumber != null ? accNumber : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAccNumber
		#region PutBankCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCodeByPK(string orderID, string bankCode, TransactionManager tm_ = null)
		{
			RepairPutBankCodeByPKData(orderID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankCodeByPKAsync(string orderID, string bankCode, TransactionManager tm_ = null)
		{
			RepairPutBankCodeByPKData(orderID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankCodeByPKData(string orderID, string bankCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCode(string bankCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
			var parameter_ = Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankCodeAsync(string bankCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
			var parameter_ = Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankCode
		#region PutIsFirstCashOfDay
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsFirstCashOfDayByPK(string orderID, bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			RepairPutIsFirstCashOfDayByPKData(orderID, isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsFirstCashOfDayByPKAsync(string orderID, bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			RepairPutIsFirstCashOfDayByPKData(orderID, isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsFirstCashOfDayByPKData(string orderID, bool isFirstCashOfDay, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsFirstCashOfDay` = @IsFirstCashOfDay  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsFirstCashOfDay(bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsFirstCashOfDay` = @IsFirstCashOfDay";
			var parameter_ = Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsFirstCashOfDayAsync(bool isFirstCashOfDay, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsFirstCashOfDay` = @IsFirstCashOfDay";
			var parameter_ = Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsFirstCashOfDay
		#region PutMeta
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMetaByPK(string orderID, string meta, TransactionManager tm_ = null)
		{
			RepairPutMetaByPKData(orderID, meta, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutMetaByPKAsync(string orderID, string meta, TransactionManager tm_ = null)
		{
			RepairPutMetaByPKData(orderID, meta, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutMetaByPKData(string orderID, string meta, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Meta` = @Meta  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Meta", meta != null ? meta : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMeta(string meta, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Meta` = @Meta";
			var parameter_ = Database.CreateInParameter("@Meta", meta != null ? meta : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutMetaAsync(string meta, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Meta` = @Meta";
			var parameter_ = Database.CreateInParameter("@Meta", meta != null ? meta : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutMeta
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string orderID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(orderID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string orderID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(orderID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string orderID, int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatus(int status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutStatusAsync(int status, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Status` = @Status";
			var parameter_ = Database.CreateInParameter("@Status", status, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutStatus
		#region PutUserIP
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIPByPK(string orderID, string userIP, TransactionManager tm_ = null)
		{
			RepairPutUserIPByPKData(orderID, userIP, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIPByPKAsync(string orderID, string userIP, TransactionManager tm_ = null)
		{
			RepairPutUserIPByPKData(orderID, userIP, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIPByPKData(string orderID, string userIP, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserIP` = @UserIP  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserIP", userIP != null ? userIP : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIP(string userIP, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserIP` = @UserIP";
			var parameter_ = Database.CreateInParameter("@UserIP", userIP != null ? userIP : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserIPAsync(string userIP, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserIP` = @UserIP";
			var parameter_ = Database.CreateInParameter("@UserIP", userIP != null ? userIP : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserIP
		#region PutOwnOrderId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnOrderIdByPK(string orderID, string ownOrderId, TransactionManager tm_ = null)
		{
			RepairPutOwnOrderIdByPKData(orderID, ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOwnOrderIdByPKAsync(string orderID, string ownOrderId, TransactionManager tm_ = null)
		{
			RepairPutOwnOrderIdByPKData(orderID, ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOwnOrderIdByPKData(string orderID, string ownOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnOrderId(string ownOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId";
			var parameter_ = Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOwnOrderIdAsync(string ownOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId";
			var parameter_ = Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOwnOrderId
		#region PutTransMoney
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransMoneyByPK(string orderID, decimal transMoney, TransactionManager tm_ = null)
		{
			RepairPutTransMoneyByPKData(orderID, transMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTransMoneyByPKAsync(string orderID, decimal transMoney, TransactionManager tm_ = null)
		{
			RepairPutTransMoneyByPKData(orderID, transMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTransMoneyByPKData(string orderID, decimal transMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TransMoney` = @TransMoney  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransMoney(decimal transMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransMoney` = @TransMoney";
			var parameter_ = Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTransMoneyAsync(decimal transMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransMoney` = @TransMoney";
			var parameter_ = Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTransMoney
		#region PutOrderMoney
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderMoneyByPK(string orderID, decimal orderMoney, TransactionManager tm_ = null)
		{
			RepairPutOrderMoneyByPKData(orderID, orderMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderMoneyByPKAsync(string orderID, decimal orderMoney, TransactionManager tm_ = null)
		{
			RepairPutOrderMoneyByPKData(orderID, orderMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderMoneyByPKData(string orderID, decimal orderMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderMoney` = @OrderMoney  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderMoney(decimal orderMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderMoney` = @OrderMoney";
			var parameter_ = Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderMoneyAsync(decimal orderMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderMoney` = @OrderMoney";
			var parameter_ = Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderMoney
		#region PutBankResponseTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankResponseTimeByPK(string orderID, DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			RepairPutBankResponseTimeByPKData(orderID, bankResponseTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankResponseTimeByPKAsync(string orderID, DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			RepairPutBankResponseTimeByPKData(orderID, bankResponseTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankResponseTimeByPKData(string orderID, DateTime? bankResponseTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankResponseTime` = @BankResponseTime  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankResponseTime", bankResponseTime.HasValue ? bankResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankResponseTime(DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankResponseTime` = @BankResponseTime";
			var parameter_ = Database.CreateInParameter("@BankResponseTime", bankResponseTime.HasValue ? bankResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankResponseTimeAsync(DateTime? bankResponseTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankResponseTime` = @BankResponseTime";
			var parameter_ = Database.CreateInParameter("@BankResponseTime", bankResponseTime.HasValue ? bankResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankResponseTime
		#region PutBankOrderId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankOrderIdByPK(string orderID, string bankOrderId, TransactionManager tm_ = null)
		{
			RepairPutBankOrderIdByPKData(orderID, bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankOrderIdByPKAsync(string orderID, string bankOrderId, TransactionManager tm_ = null)
		{
			RepairPutBankOrderIdByPKData(orderID, bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankOrderIdByPKData(string orderID, string bankOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankOrderId` = @BankOrderId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankOrderId", bankOrderId != null ? bankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankOrderId(string bankOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankOrderId` = @BankOrderId";
			var parameter_ = Database.CreateInParameter("@BankOrderId", bankOrderId != null ? bankOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankOrderIdAsync(string bankOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankOrderId` = @BankOrderId";
			var parameter_ = Database.CreateInParameter("@BankOrderId", bankOrderId != null ? bankOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankOrderId
		#region PutBankCallbackTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCallbackTimeByPK(string orderID, DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			RepairPutBankCallbackTimeByPKData(orderID, bankCallbackTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankCallbackTimeByPKAsync(string orderID, DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			RepairPutBankCallbackTimeByPKData(orderID, bankCallbackTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankCallbackTimeByPKData(string orderID, DateTime? bankCallbackTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankCallbackTime` = @BankCallbackTime  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.HasValue ? bankCallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCallbackTime(DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCallbackTime` = @BankCallbackTime";
			var parameter_ = Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.HasValue ? bankCallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankCallbackTimeAsync(DateTime? bankCallbackTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCallbackTime` = @BankCallbackTime";
			var parameter_ = Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.HasValue ? bankCallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankCallbackTime
		#region PutBankTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankTimeByPK(string orderID, DateTime? bankTime, TransactionManager tm_ = null)
		{
			RepairPutBankTimeByPKData(orderID, bankTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankTimeByPKAsync(string orderID, DateTime? bankTime, TransactionManager tm_ = null)
		{
			RepairPutBankTimeByPKData(orderID, bankTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankTimeByPKData(string orderID, DateTime? bankTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankTime` = @BankTime  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankTime", bankTime.HasValue ? bankTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankTime(DateTime? bankTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankTime` = @BankTime";
			var parameter_ = Database.CreateInParameter("@BankTime", bankTime.HasValue ? bankTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankTimeAsync(DateTime? bankTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankTime` = @BankTime";
			var parameter_ = Database.CreateInParameter("@BankTime", bankTime.HasValue ? bankTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankTime
		#region PutBrCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBrCodeByPK(string orderID, string brCode, TransactionManager tm_ = null)
		{
			RepairPutBrCodeByPKData(orderID, brCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBrCodeByPKAsync(string orderID, string brCode, TransactionManager tm_ = null)
		{
			RepairPutBrCodeByPKData(orderID, brCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBrCodeByPKData(string orderID, string brCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BrCode` = @BrCode  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BrCode", brCode != null ? brCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBrCode(string brCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BrCode` = @BrCode";
			var parameter_ = Database.CreateInParameter("@BrCode", brCode != null ? brCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBrCodeAsync(string brCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BrCode` = @BrCode";
			var parameter_ = Database.CreateInParameter("@BrCode", brCode != null ? brCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBrCode
		#region PutQrCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutQrCodeByPK(string orderID, string qrCode, TransactionManager tm_ = null)
		{
			RepairPutQrCodeByPKData(orderID, qrCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutQrCodeByPKAsync(string orderID, string qrCode, TransactionManager tm_ = null)
		{
			RepairPutQrCodeByPKData(orderID, qrCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutQrCodeByPKData(string orderID, string qrCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `QrCode` = @QrCode  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@QrCode", qrCode != null ? qrCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutQrCode(string qrCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `QrCode` = @QrCode";
			var parameter_ = Database.CreateInParameter("@QrCode", qrCode != null ? qrCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutQrCodeAsync(string qrCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `QrCode` = @QrCode";
			var parameter_ = Database.CreateInParameter("@QrCode", qrCode != null ? qrCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutQrCode
		#region PutAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountByPK(string orderID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(orderID, amount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountByPKAsync(string orderID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(orderID, amount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountByPKData(string orderID, long amount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Amount` = @Amount  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmount(long amount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Amount` = @Amount";
			var parameter_ = Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAmountAsync(long amount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Amount` = @Amount";
			var parameter_ = Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAmount
		#region PutOwnFee
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnFeeByPK(string orderID, decimal ownFee, TransactionManager tm_ = null)
		{
			RepairPutOwnFeeByPKData(orderID, ownFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOwnFeeByPKAsync(string orderID, decimal ownFee, TransactionManager tm_ = null)
		{
			RepairPutOwnFeeByPKData(orderID, ownFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOwnFeeByPKData(string orderID, decimal ownFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OwnFee` = @OwnFee  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnFee(decimal ownFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnFee` = @OwnFee";
			var parameter_ = Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOwnFeeAsync(decimal ownFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnFee` = @OwnFee";
			var parameter_ = Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOwnFee
		#region PutUserFee
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserFeeByPK(string orderID, decimal userFee, TransactionManager tm_ = null)
		{
			RepairPutUserFeeByPKData(orderID, userFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserFeeByPKAsync(string orderID, decimal userFee, TransactionManager tm_ = null)
		{
			RepairPutUserFeeByPKData(orderID, userFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserFeeByPKData(string orderID, decimal userFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserFee` = @UserFee  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserFee(decimal userFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserFee` = @UserFee";
			var parameter_ = Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserFeeAsync(decimal userFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserFee` = @UserFee";
			var parameter_ = Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserFee
		#region PutUserMoney
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserMoneyByPK(string orderID, decimal userMoney, TransactionManager tm_ = null)
		{
			RepairPutUserMoneyByPKData(orderID, userMoney, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserMoneyByPKAsync(string orderID, decimal userMoney, TransactionManager tm_ = null)
		{
			RepairPutUserMoneyByPKData(orderID, userMoney, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserMoneyByPKData(string orderID, decimal userMoney, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserMoney` = @UserMoney  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserMoney(decimal userMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserMoney` = @UserMoney";
			var parameter_ = Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserMoneyAsync(decimal userMoney, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserMoney` = @UserMoney";
			var parameter_ = Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserMoney
		#region PutEndBalance
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBalanceByPK(string orderID, long endBalance, TransactionManager tm_ = null)
		{
			RepairPutEndBalanceByPKData(orderID, endBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutEndBalanceByPKAsync(string orderID, long endBalance, TransactionManager tm_ = null)
		{
			RepairPutEndBalanceByPKData(orderID, endBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutEndBalanceByPKData(string orderID, long endBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `EndBalance` = @EndBalance  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBalance(long endBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBalance` = @EndBalance";
			var parameter_ = Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutEndBalanceAsync(long endBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBalance` = @EndBalance";
			var parameter_ = Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutEndBalance
		#region PutAmountBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountBonusByPK(string orderID, long amountBonus, TransactionManager tm_ = null)
		{
			RepairPutAmountBonusByPKData(orderID, amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountBonusByPKAsync(string orderID, long amountBonus, TransactionManager tm_ = null)
		{
			RepairPutAmountBonusByPKData(orderID, amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountBonusByPKData(string orderID, long amountBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AmountBonus` = @AmountBonus  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountBonus(long amountBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AmountBonus` = @AmountBonus";
			var parameter_ = Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAmountBonusAsync(long amountBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AmountBonus` = @AmountBonus";
			var parameter_ = Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAmountBonus
		#region PutEndBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBonusByPK(string orderID, long endBonus, TransactionManager tm_ = null)
		{
			RepairPutEndBonusByPKData(orderID, endBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutEndBonusByPKAsync(string orderID, long endBonus, TransactionManager tm_ = null)
		{
			RepairPutEndBonusByPKData(orderID, endBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutEndBonusByPKData(string orderID, long endBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `EndBonus` = @EndBonus  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBonus(long endBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBonus` = @EndBonus";
			var parameter_ = Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutEndBonusAsync(long endBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBonus` = @EndBonus";
			var parameter_ = Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutEndBonus
		#region PutSettlTable
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlTableByPK(string orderID, string settlTable, TransactionManager tm_ = null)
		{
			RepairPutSettlTableByPKData(orderID, settlTable, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSettlTableByPKAsync(string orderID, string settlTable, TransactionManager tm_ = null)
		{
			RepairPutSettlTableByPKData(orderID, settlTable, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSettlTableByPKData(string orderID, string settlTable, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SettlTable` = @SettlTable  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SettlTable", settlTable != null ? settlTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlTable(string settlTable, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlTable` = @SettlTable";
			var parameter_ = Database.CreateInParameter("@SettlTable", settlTable != null ? settlTable : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSettlTableAsync(string settlTable, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlTable` = @SettlTable";
			var parameter_ = Database.CreateInParameter("@SettlTable", settlTable != null ? settlTable : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSettlTable
		#region PutSettlId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlIdByPK(string orderID, string settlId, TransactionManager tm_ = null)
		{
			RepairPutSettlIdByPKData(orderID, settlId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSettlIdByPKAsync(string orderID, string settlId, TransactionManager tm_ = null)
		{
			RepairPutSettlIdByPKData(orderID, settlId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSettlIdByPKData(string orderID, string settlId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SettlId` = @SettlId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SettlId", settlId != null ? settlId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlId(string settlId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlId` = @SettlId";
			var parameter_ = Database.CreateInParameter("@SettlId", settlId != null ? settlId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSettlIdAsync(string settlId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlId` = @SettlId";
			var parameter_ = Database.CreateInParameter("@SettlId", settlId != null ? settlId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSettlId
		#region PutSettlAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlAmountByPK(string orderID, long settlAmount, TransactionManager tm_ = null)
		{
			RepairPutSettlAmountByPKData(orderID, settlAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSettlAmountByPKAsync(string orderID, long settlAmount, TransactionManager tm_ = null)
		{
			RepairPutSettlAmountByPKData(orderID, settlAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSettlAmountByPKData(string orderID, long settlAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SettlAmount` = @SettlAmount  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlAmount(long settlAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlAmount` = @SettlAmount";
			var parameter_ = Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSettlAmountAsync(long settlAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlAmount` = @SettlAmount";
			var parameter_ = Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSettlAmount
		#region PutSettlStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlStatusByPK(string orderID, int settlStatus, TransactionManager tm_ = null)
		{
			RepairPutSettlStatusByPKData(orderID, settlStatus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSettlStatusByPKAsync(string orderID, int settlStatus, TransactionManager tm_ = null)
		{
			RepairPutSettlStatusByPKData(orderID, settlStatus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSettlStatusByPKData(string orderID, int settlStatus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SettlStatus` = @SettlStatus  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSettlStatus(int settlStatus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlStatus` = @SettlStatus";
			var parameter_ = Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSettlStatusAsync(int settlStatus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SettlStatus` = @SettlStatus";
			var parameter_ = Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSettlStatus
		#region PutCompleteFlag
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCompleteFlagByPK(string orderID, int completeFlag, TransactionManager tm_ = null)
		{
			RepairPutCompleteFlagByPKData(orderID, completeFlag, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCompleteFlagByPKAsync(string orderID, int completeFlag, TransactionManager tm_ = null)
		{
			RepairPutCompleteFlagByPKData(orderID, completeFlag, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCompleteFlagByPKData(string orderID, int completeFlag, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CompleteFlag` = @CompleteFlag  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCompleteFlag(int completeFlag, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CompleteFlag` = @CompleteFlag";
			var parameter_ = Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCompleteFlagAsync(int completeFlag, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CompleteFlag` = @CompleteFlag";
			var parameter_ = Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCompleteFlag
		#region PutActivityIds
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutActivityIdsByPK(string orderID, string activityIds, TransactionManager tm_ = null)
		{
			RepairPutActivityIdsByPKData(orderID, activityIds, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutActivityIdsByPKAsync(string orderID, string activityIds, TransactionManager tm_ = null)
		{
			RepairPutActivityIdsByPKData(orderID, activityIds, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutActivityIdsByPKData(string orderID, string activityIds, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ActivityIds` = @ActivityIds  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ActivityIds", activityIds != null ? activityIds : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutActivityIds(string activityIds, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ActivityIds` = @ActivityIds";
			var parameter_ = Database.CreateInParameter("@ActivityIds", activityIds != null ? activityIds : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutActivityIdsAsync(string activityIds, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ActivityIds` = @ActivityIds";
			var parameter_ = Database.CreateInParameter("@ActivityIds", activityIds != null ? activityIds : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutActivityIds
		#region PutIsAddBalance
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAddBalanceByPK(string orderID, bool isAddBalance, TransactionManager tm_ = null)
		{
			RepairPutIsAddBalanceByPKData(orderID, isAddBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsAddBalanceByPKAsync(string orderID, bool isAddBalance, TransactionManager tm_ = null)
		{
			RepairPutIsAddBalanceByPKData(orderID, isAddBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsAddBalanceByPKData(string orderID, bool isAddBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsAddBalance` = @IsAddBalance  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAddBalance(bool isAddBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAddBalance` = @IsAddBalance";
			var parameter_ = Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsAddBalanceAsync(bool isAddBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAddBalance` = @IsAddBalance";
			var parameter_ = Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsAddBalance
		#region PutIsAuditOrder
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAuditOrderByPK(string orderID, bool isAuditOrder, TransactionManager tm_ = null)
		{
			RepairPutIsAuditOrderByPKData(orderID, isAuditOrder, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsAuditOrderByPKAsync(string orderID, bool isAuditOrder, TransactionManager tm_ = null)
		{
			RepairPutIsAuditOrderByPKData(orderID, isAuditOrder, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsAuditOrderByPKData(string orderID, bool isAuditOrder, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsAuditOrder` = @IsAuditOrder  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAuditOrder(bool isAuditOrder, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAuditOrder` = @IsAuditOrder";
			var parameter_ = Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsAuditOrderAsync(bool isAuditOrder, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAuditOrder` = @IsAuditOrder";
			var parameter_ = Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsAuditOrder
		#region PutCountryID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(string orderID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(orderID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(string orderID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(orderID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(string orderID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryID(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCountryID
		#region PutUserFeeAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserFeeAmountByPK(string orderID, long userFeeAmount, TransactionManager tm_ = null)
		{
			RepairPutUserFeeAmountByPKData(orderID, userFeeAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserFeeAmountByPKAsync(string orderID, long userFeeAmount, TransactionManager tm_ = null)
		{
			RepairPutUserFeeAmountByPKData(orderID, userFeeAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserFeeAmountByPKData(string orderID, long userFeeAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserFeeAmount` = @UserFeeAmount  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserFeeAmount(long userFeeAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserFeeAmount` = @UserFeeAmount";
			var parameter_ = Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserFeeAmountAsync(long userFeeAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserFeeAmount` = @UserFeeAmount";
			var parameter_ = Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserFeeAmount
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_bank_orderEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OrderID) == null)
			{
				Add(item, tm);
			}
			else
			{
				Put(item, tm);
				ret = false;
			}
			return ret;
		}
		public async Task<bool> SetAsync(Sb_bank_orderEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OrderID) == null)
			{
				await AddAsync(item, tm);
			}
			else
			{
				await PutAsync(item, tm);
				ret = false;
			}
			return ret;
		}
		
		#endregion // Set
		
		#region Get
		#region GetByPK
		/// <summary>
		/// 按 PK（主键） 查询
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_bank_orderEO GetByPK(string orderID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(orderID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<Sb_bank_orderEO> GetByPKAsync(string orderID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(orderID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		private void RepairGetByPKData(string orderID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`OrderID` = @OrderID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 ProviderID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetProviderIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`ProviderID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetProviderIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`ProviderID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAppIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromMode（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetFromModeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`FromMode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetFromModeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`FromMode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromId（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetFromIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`FromId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetFromIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`FromId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 DomainID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetDomainIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`DomainID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetDomainIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`DomainID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserKind（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetUserKindByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`UserKind`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetUserKindByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`UserKind`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RegistDate（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetRegistDateByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`RegistDate`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime?> GetRegistDateByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`RegistDate`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderType（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetOrderTypeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`OrderType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetOrderTypeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`OrderType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetBankIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PaytypeID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetPaytypeIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`PaytypeID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetPaytypeIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`PaytypeID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PaytypeChannel（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetPaytypeChannelByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`PaytypeChannel`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetPaytypeChannelByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`PaytypeChannel`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CurrencyID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PlanAmount（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPlanAmountByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`PlanAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetPlanAmountByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`PlanAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppRequestUUID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppRequestUUIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppRequestUUID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAppRequestUUIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppRequestUUID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppOrderId（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppOrderIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAppOrderIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppReqComment（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppReqCommentByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppReqComment`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAppReqCommentByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppReqComment`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppRequestTime（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetAppRequestTimeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`AppRequestTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime> GetAppRequestTimeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`AppRequestTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AccName（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAccNameByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AccName`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAccNameByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AccName`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AccNumber（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAccNumberByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AccNumber`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetAccNumberByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AccNumber`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankCode（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankCodeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetBankCodeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsFirstCashOfDay（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsFirstCashOfDayByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsFirstCashOfDay`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<bool> GetIsFirstCashOfDayByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsFirstCashOfDay`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Meta（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetMetaByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Meta`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetMetaByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Meta`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetStatusByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Status`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetStatusByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Status`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserIP（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIPByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserIP`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetUserIPByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserIP`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OwnOrderId（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOwnOrderIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OwnOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetOwnOrderIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OwnOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TransMoney（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetTransMoneyByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`TransMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<decimal> GetTransMoneyByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`TransMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderMoney（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetOrderMoneyByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`OrderMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<decimal> GetOrderMoneyByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`OrderMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankResponseTime（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetBankResponseTimeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`BankResponseTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime?> GetBankResponseTimeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`BankResponseTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankOrderId（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankOrderIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetBankOrderIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankOrderId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankCallbackTime（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetBankCallbackTimeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`BankCallbackTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime?> GetBankCallbackTimeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`BankCallbackTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankTime（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetBankTimeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`BankTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime?> GetBankTimeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`BankTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BrCode（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBrCodeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BrCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetBrCodeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BrCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 QrCode（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetQrCodeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`QrCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetQrCodeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`QrCode`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Amount（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`Amount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetAmountByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`Amount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OwnFee（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetOwnFeeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`OwnFee`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<decimal> GetOwnFeeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`OwnFee`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserFee（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetUserFeeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`UserFee`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<decimal> GetUserFeeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`UserFee`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserMoney（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetUserMoneyByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`UserMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<decimal> GetUserMoneyByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`UserMoney`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 EndBalance（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetEndBalanceByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`EndBalance`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetEndBalanceByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`EndBalance`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AmountBonus（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountBonusByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`AmountBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetAmountBonusByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`AmountBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 EndBonus（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetEndBonusByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`EndBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetEndBonusByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`EndBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SettlTable（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetSettlTableByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`SettlTable`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetSettlTableByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`SettlTable`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SettlId（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetSettlIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`SettlId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetSettlIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`SettlId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SettlAmount（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetSettlAmountByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`SettlAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetSettlAmountByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`SettlAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SettlStatus（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetSettlStatusByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`SettlStatus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetSettlStatusByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`SettlStatus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CompleteFlag（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetCompleteFlagByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`CompleteFlag`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetCompleteFlagByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`CompleteFlag`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ActivityIds（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetActivityIdsByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`ActivityIds`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetActivityIdsByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`ActivityIds`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsAddBalance（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsAddBalanceByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsAddBalance`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<bool> GetIsAddBalanceByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsAddBalance`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsAuditOrder（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsAuditOrderByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsAuditOrder`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<bool> GetIsAuditOrderByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsAuditOrder`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserFeeAmount（字段）
		/// </summary>
		/// /// <param name = "orderID">订单编码GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetUserFeeAmountByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`UserFeeAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetUserFeeAmountByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`UserFeeAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByProviderID
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID)
		{
			return GetByProviderID(providerID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, int top_)
		{
			return GetByProviderID(providerID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, int top_)
		{
			return await GetByProviderIDAsync(providerID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, int top_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, int top_, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, string sort_)
		{
			return GetByProviderID(providerID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, string sort_)
		{
			return await GetByProviderIDAsync(providerID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, string sort_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, string sort_, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByProviderID(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(providerID != null ? "`ProviderID` = @ProviderID" : "`ProviderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (providerID != null)
				paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByProviderIDAsync(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(providerID != null ? "`ProviderID` = @ProviderID" : "`ProviderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (providerID != null)
				paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByProviderID
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, int top_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, string sort_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, int top_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, string sort_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, int top_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, string sort_)
		{
			return await GetByUserIDAsync(userID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByFromMode
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode)
		{
			return GetByFromMode(fromMode, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, int top_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, int top_)
		{
			return await GetByFromModeAsync(fromMode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, int top_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, int top_, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, string sort_)
		{
			return GetByFromMode(fromMode, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, string sort_)
		{
			return await GetByFromModeAsync(fromMode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, string sort_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, string sort_, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromMode(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromModeAsync(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByFromMode
		#region GetByFromId
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId)
		{
			return GetByFromId(fromId, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, int top_)
		{
			return GetByFromId(fromId, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, int top_)
		{
			return await GetByFromIdAsync(fromId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, int top_, TransactionManager tm_)
		{
			return GetByFromId(fromId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, int top_, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, string sort_)
		{
			return GetByFromId(fromId, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, string sort_)
		{
			return await GetByFromIdAsync(fromId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, string sort_, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, string sort_, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByFromId(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByFromIdAsync(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByFromId
		#region GetByDomainID
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID)
		{
			return GetByDomainID(domainID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID)
		{
			return await GetByDomainIDAsync(domainID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, TransactionManager tm_)
		{
			return GetByDomainID(domainID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, TransactionManager tm_)
		{
			return await GetByDomainIDAsync(domainID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, int top_)
		{
			return GetByDomainID(domainID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, int top_)
		{
			return await GetByDomainIDAsync(domainID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, int top_, TransactionManager tm_)
		{
			return GetByDomainID(domainID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, int top_, TransactionManager tm_)
		{
			return await GetByDomainIDAsync(domainID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, string sort_)
		{
			return GetByDomainID(domainID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, string sort_)
		{
			return await GetByDomainIDAsync(domainID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, string sort_, TransactionManager tm_)
		{
			return GetByDomainID(domainID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, string sort_, TransactionManager tm_)
		{
			return await GetByDomainIDAsync(domainID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DomainID（字段） 查询
		/// </summary>
		/// /// <param name = "domainID">域名（不带http）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByDomainID(string domainID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(domainID != null ? "`DomainID` = @DomainID" : "`DomainID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (domainID != null)
				paras_.Add(Database.CreateInParameter("@DomainID", domainID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByDomainIDAsync(string domainID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(domainID != null ? "`DomainID` = @DomainID" : "`DomainID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (domainID != null)
				paras_.Add(Database.CreateInParameter("@DomainID", domainID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByDomainID
		#region GetByUserKind
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind)
		{
			return GetByUserKind(userKind, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, int top_)
		{
			return GetByUserKind(userKind, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, int top_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, string sort_)
		{
			return GetByUserKind(userKind, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, string sort_)
		{
			return await GetByUserKindAsync(userKind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserKind
		#region GetByRegistDate
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate)
		{
			return GetByRegistDate(registDate, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate)
		{
			return await GetByRegistDateAsync(registDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, TransactionManager tm_)
		{
			return GetByRegistDate(registDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, TransactionManager tm_)
		{
			return await GetByRegistDateAsync(registDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, int top_)
		{
			return GetByRegistDate(registDate, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, int top_)
		{
			return await GetByRegistDateAsync(registDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, int top_, TransactionManager tm_)
		{
			return GetByRegistDate(registDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, int top_, TransactionManager tm_)
		{
			return await GetByRegistDateAsync(registDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, string sort_)
		{
			return GetByRegistDate(registDate, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, string sort_)
		{
			return await GetByRegistDateAsync(registDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, string sort_, TransactionManager tm_)
		{
			return GetByRegistDate(registDate, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, string sort_, TransactionManager tm_)
		{
			return await GetByRegistDateAsync(registDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RegistDate（字段） 查询
		/// </summary>
		/// /// <param name = "registDate">注册时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRegistDate(DateTime? registDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(registDate.HasValue ? "`RegistDate` = @RegistDate" : "`RegistDate` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (registDate.HasValue)
				paras_.Add(Database.CreateInParameter("@RegistDate", registDate.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRegistDateAsync(DateTime? registDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(registDate.HasValue ? "`RegistDate` = @RegistDate" : "`RegistDate` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (registDate.HasValue)
				paras_.Add(Database.CreateInParameter("@RegistDate", registDate.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByRegistDate
		#region GetByOrderType
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType)
		{
			return GetByOrderType(orderType, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType)
		{
			return await GetByOrderTypeAsync(orderType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, TransactionManager tm_)
		{
			return GetByOrderType(orderType, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, TransactionManager tm_)
		{
			return await GetByOrderTypeAsync(orderType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, int top_)
		{
			return GetByOrderType(orderType, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, int top_)
		{
			return await GetByOrderTypeAsync(orderType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, int top_, TransactionManager tm_)
		{
			return GetByOrderType(orderType, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, int top_, TransactionManager tm_)
		{
			return await GetByOrderTypeAsync(orderType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, string sort_)
		{
			return GetByOrderType(orderType, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, string sort_)
		{
			return await GetByOrderTypeAsync(orderType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, string sort_, TransactionManager tm_)
		{
			return GetByOrderType(orderType, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, string sort_, TransactionManager tm_)
		{
			return await GetByOrderTypeAsync(orderType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderType（字段） 查询
		/// </summary>
		/// /// <param name = "orderType">充值返现1-充值2-返现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderType(int orderType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderType` = @OrderType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderTypeAsync(int orderType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderType` = @OrderType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderType", orderType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByOrderType
		#region GetByBankID
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID)
		{
			return GetByBankID(bankID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, int top_)
		{
			return GetByBankID(bankID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, int top_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, int top_, TransactionManager tm_)
		{
			return GetByBankID(bankID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, int top_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, string sort_)
		{
			return GetByBankID(bankID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, string sort_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, string sort_, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, string sort_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankID(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankID != null ? "`BankID` = @BankID" : "`BankID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankID != null)
				paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankIDAsync(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankID != null ? "`BankID` = @BankID" : "`BankID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankID != null)
				paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankID
		#region GetByPaytypeID
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID)
		{
			return GetByPaytypeID(paytypeID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID)
		{
			return await GetByPaytypeIDAsync(paytypeID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, TransactionManager tm_)
		{
			return GetByPaytypeID(paytypeID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, TransactionManager tm_)
		{
			return await GetByPaytypeIDAsync(paytypeID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, int top_)
		{
			return GetByPaytypeID(paytypeID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, int top_)
		{
			return await GetByPaytypeIDAsync(paytypeID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, int top_, TransactionManager tm_)
		{
			return GetByPaytypeID(paytypeID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, int top_, TransactionManager tm_)
		{
			return await GetByPaytypeIDAsync(paytypeID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, string sort_)
		{
			return GetByPaytypeID(paytypeID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, string sort_)
		{
			return await GetByPaytypeIDAsync(paytypeID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, string sort_, TransactionManager tm_)
		{
			return GetByPaytypeID(paytypeID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, string sort_, TransactionManager tm_)
		{
			return await GetByPaytypeIDAsync(paytypeID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeID（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeID">支付方式0-综合1-visa2-spei</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeID(int paytypeID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PaytypeID` = @PaytypeID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeIDAsync(int paytypeID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PaytypeID` = @PaytypeID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByPaytypeID
		#region GetByPaytypeChannel
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel)
		{
			return GetByPaytypeChannel(paytypeChannel, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, TransactionManager tm_)
		{
			return GetByPaytypeChannel(paytypeChannel, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, TransactionManager tm_)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, int top_)
		{
			return GetByPaytypeChannel(paytypeChannel, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, int top_)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, int top_, TransactionManager tm_)
		{
			return GetByPaytypeChannel(paytypeChannel, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, int top_, TransactionManager tm_)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, string sort_)
		{
			return GetByPaytypeChannel(paytypeChannel, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, string sort_)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, string sort_, TransactionManager tm_)
		{
			return GetByPaytypeChannel(paytypeChannel, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, string sort_, TransactionManager tm_)
		{
			return await GetByPaytypeChannelAsync(paytypeChannel, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PaytypeChannel（字段） 查询
		/// </summary>
		/// /// <param name = "paytypeChannel">支付方式下的渠道</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPaytypeChannel(int paytypeChannel, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PaytypeChannel` = @PaytypeChannel", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPaytypeChannelAsync(int paytypeChannel, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PaytypeChannel` = @PaytypeChannel", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PaytypeChannel", paytypeChannel, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByPaytypeChannel
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, int top_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, string sort_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByPlanAmount
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount)
		{
			return GetByPlanAmount(planAmount, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount)
		{
			return await GetByPlanAmountAsync(planAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, TransactionManager tm_)
		{
			return GetByPlanAmount(planAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, TransactionManager tm_)
		{
			return await GetByPlanAmountAsync(planAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, int top_)
		{
			return GetByPlanAmount(planAmount, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, int top_)
		{
			return await GetByPlanAmountAsync(planAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, int top_, TransactionManager tm_)
		{
			return GetByPlanAmount(planAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, int top_, TransactionManager tm_)
		{
			return await GetByPlanAmountAsync(planAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, string sort_)
		{
			return GetByPlanAmount(planAmount, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, string sort_)
		{
			return await GetByPlanAmountAsync(planAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, string sort_, TransactionManager tm_)
		{
			return GetByPlanAmount(planAmount, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPlanAmountAsync(planAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PlanAmount（字段） 查询
		/// </summary>
		/// /// <param name = "planAmount">计划变化金额（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByPlanAmount(long planAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PlanAmount` = @PlanAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByPlanAmountAsync(long planAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PlanAmount` = @PlanAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PlanAmount", planAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByPlanAmount
		#region GetByAppRequestUUID
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID)
		{
			return GetByAppRequestUUID(appRequestUUID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, TransactionManager tm_)
		{
			return GetByAppRequestUUID(appRequestUUID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, TransactionManager tm_)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, int top_)
		{
			return GetByAppRequestUUID(appRequestUUID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, int top_)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, int top_, TransactionManager tm_)
		{
			return GetByAppRequestUUID(appRequestUUID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, int top_, TransactionManager tm_)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, string sort_)
		{
			return GetByAppRequestUUID(appRequestUUID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, string sort_)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, string sort_, TransactionManager tm_)
		{
			return GetByAppRequestUUID(appRequestUUID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, string sort_, TransactionManager tm_)
		{
			return await GetByAppRequestUUIDAsync(appRequestUUID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestUUID（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestUUID">请求唯一号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestUUID(string appRequestUUID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appRequestUUID != null ? "`AppRequestUUID` = @AppRequestUUID" : "`AppRequestUUID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appRequestUUID != null)
				paras_.Add(Database.CreateInParameter("@AppRequestUUID", appRequestUUID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestUUIDAsync(string appRequestUUID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appRequestUUID != null ? "`AppRequestUUID` = @AppRequestUUID" : "`AppRequestUUID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appRequestUUID != null)
				paras_.Add(Database.CreateInParameter("@AppRequestUUID", appRequestUUID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAppRequestUUID
		#region GetByAppOrderId
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId)
		{
			return GetByAppOrderId(appOrderId, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId)
		{
			return await GetByAppOrderIdAsync(appOrderId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, TransactionManager tm_)
		{
			return GetByAppOrderId(appOrderId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, TransactionManager tm_)
		{
			return await GetByAppOrderIdAsync(appOrderId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, int top_)
		{
			return GetByAppOrderId(appOrderId, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, int top_)
		{
			return await GetByAppOrderIdAsync(appOrderId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, int top_, TransactionManager tm_)
		{
			return GetByAppOrderId(appOrderId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, int top_, TransactionManager tm_)
		{
			return await GetByAppOrderIdAsync(appOrderId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, string sort_)
		{
			return GetByAppOrderId(appOrderId, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, string sort_)
		{
			return await GetByAppOrderIdAsync(appOrderId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, string sort_, TransactionManager tm_)
		{
			return GetByAppOrderId(appOrderId, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, string sort_, TransactionManager tm_)
		{
			return await GetByAppOrderIdAsync(appOrderId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "appOrderId">app订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppOrderId(string appOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appOrderId != null ? "`AppOrderId` = @AppOrderId" : "`AppOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appOrderId != null)
				paras_.Add(Database.CreateInParameter("@AppOrderId", appOrderId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppOrderIdAsync(string appOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appOrderId != null ? "`AppOrderId` = @AppOrderId" : "`AppOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appOrderId != null)
				paras_.Add(Database.CreateInParameter("@AppOrderId", appOrderId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAppOrderId
		#region GetByAppReqComment
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment)
		{
			return GetByAppReqComment(appReqComment, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment)
		{
			return await GetByAppReqCommentAsync(appReqComment, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, TransactionManager tm_)
		{
			return GetByAppReqComment(appReqComment, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, TransactionManager tm_)
		{
			return await GetByAppReqCommentAsync(appReqComment, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, int top_)
		{
			return GetByAppReqComment(appReqComment, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, int top_)
		{
			return await GetByAppReqCommentAsync(appReqComment, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, int top_, TransactionManager tm_)
		{
			return GetByAppReqComment(appReqComment, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, int top_, TransactionManager tm_)
		{
			return await GetByAppReqCommentAsync(appReqComment, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, string sort_)
		{
			return GetByAppReqComment(appReqComment, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, string sort_)
		{
			return await GetByAppReqCommentAsync(appReqComment, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, string sort_, TransactionManager tm_)
		{
			return GetByAppReqComment(appReqComment, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, string sort_, TransactionManager tm_)
		{
			return await GetByAppReqCommentAsync(appReqComment, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppReqComment（字段） 查询
		/// </summary>
		/// /// <param name = "appReqComment">请求备注</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppReqComment(string appReqComment, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appReqComment != null ? "`AppReqComment` = @AppReqComment" : "`AppReqComment` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appReqComment != null)
				paras_.Add(Database.CreateInParameter("@AppReqComment", appReqComment, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppReqCommentAsync(string appReqComment, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appReqComment != null ? "`AppReqComment` = @AppReqComment" : "`AppReqComment` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appReqComment != null)
				paras_.Add(Database.CreateInParameter("@AppReqComment", appReqComment, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAppReqComment
		#region GetByAppRequestTime
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime)
		{
			return GetByAppRequestTime(appRequestTime, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, TransactionManager tm_)
		{
			return GetByAppRequestTime(appRequestTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, TransactionManager tm_)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, int top_)
		{
			return GetByAppRequestTime(appRequestTime, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, int top_)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, int top_, TransactionManager tm_)
		{
			return GetByAppRequestTime(appRequestTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, int top_, TransactionManager tm_)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, string sort_)
		{
			return GetByAppRequestTime(appRequestTime, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, string sort_)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, string sort_, TransactionManager tm_)
		{
			return GetByAppRequestTime(appRequestTime, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, string sort_, TransactionManager tm_)
		{
			return await GetByAppRequestTimeAsync(appRequestTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppRequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "appRequestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAppRequestTime(DateTime appRequestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AppRequestTime` = @AppRequestTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAppRequestTimeAsync(DateTime appRequestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AppRequestTime` = @AppRequestTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AppRequestTime", appRequestTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAppRequestTime
		#region GetByAccName
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName)
		{
			return GetByAccName(accName, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName)
		{
			return await GetByAccNameAsync(accName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, TransactionManager tm_)
		{
			return GetByAccName(accName, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, int top_)
		{
			return GetByAccName(accName, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, int top_)
		{
			return await GetByAccNameAsync(accName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, int top_, TransactionManager tm_)
		{
			return GetByAccName(accName, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, int top_, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, string sort_)
		{
			return GetByAccName(accName, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, string sort_)
		{
			return await GetByAccNameAsync(accName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, string sort_, TransactionManager tm_)
		{
			return GetByAccName(accName, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, string sort_, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccName(string accName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accName != null ? "`AccName` = @AccName" : "`AccName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accName != null)
				paras_.Add(Database.CreateInParameter("@AccName", accName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNameAsync(string accName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accName != null ? "`AccName` = @AccName" : "`AccName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accName != null)
				paras_.Add(Database.CreateInParameter("@AccName", accName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAccName
		#region GetByAccNumber
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber)
		{
			return GetByAccNumber(accNumber, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber)
		{
			return await GetByAccNumberAsync(accNumber, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, int top_)
		{
			return GetByAccNumber(accNumber, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, int top_)
		{
			return await GetByAccNumberAsync(accNumber, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, int top_, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, int top_, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, string sort_)
		{
			return GetByAccNumber(accNumber, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, string sort_)
		{
			return await GetByAccNumberAsync(accNumber, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, string sort_, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, string sort_, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">账户卡号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAccNumber(string accNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accNumber != null ? "`AccNumber` = @AccNumber" : "`AccNumber` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accNumber != null)
				paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAccNumberAsync(string accNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accNumber != null ? "`AccNumber` = @AccNumber" : "`AccNumber` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accNumber != null)
				paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAccNumber
		#region GetByBankCode
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode)
		{
			return GetByBankCode(bankCode, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, int top_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, int top_)
		{
			return await GetByBankCodeAsync(bankCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, int top_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, int top_, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, string sort_)
		{
			return GetByBankCode(bankCode, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, string sort_)
		{
			return await GetByBankCodeAsync(bankCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, string sort_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, string sort_, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCode(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCode != null)
				paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCodeAsync(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCode != null)
				paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankCode
		#region GetByIsFirstCashOfDay
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, TransactionManager tm_)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, TransactionManager tm_)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, int top_)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, int top_)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, int top_, TransactionManager tm_)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, int top_, TransactionManager tm_)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, string sort_)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, string sort_)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, string sort_, TransactionManager tm_)
		{
			return GetByIsFirstCashOfDay(isFirstCashOfDay, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, string sort_, TransactionManager tm_)
		{
			return await GetByIsFirstCashOfDayAsync(isFirstCashOfDay, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsFirstCashOfDay（字段） 查询
		/// </summary>
		/// /// <param name = "isFirstCashOfDay">是否当天第一次提现</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsFirstCashOfDay(bool isFirstCashOfDay, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsFirstCashOfDay` = @IsFirstCashOfDay", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsFirstCashOfDayAsync(bool isFirstCashOfDay, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsFirstCashOfDay` = @IsFirstCashOfDay", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsFirstCashOfDay", isFirstCashOfDay, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByIsFirstCashOfDay
		#region GetByMeta
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta)
		{
			return GetByMeta(meta, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta)
		{
			return await GetByMetaAsync(meta, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, TransactionManager tm_)
		{
			return GetByMeta(meta, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, TransactionManager tm_)
		{
			return await GetByMetaAsync(meta, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, int top_)
		{
			return GetByMeta(meta, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, int top_)
		{
			return await GetByMetaAsync(meta, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, int top_, TransactionManager tm_)
		{
			return GetByMeta(meta, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, int top_, TransactionManager tm_)
		{
			return await GetByMetaAsync(meta, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, string sort_)
		{
			return GetByMeta(meta, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, string sort_)
		{
			return await GetByMetaAsync(meta, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, string sort_, TransactionManager tm_)
		{
			return GetByMeta(meta, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, string sort_, TransactionManager tm_)
		{
			return await GetByMetaAsync(meta, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Meta（字段） 查询
		/// </summary>
		/// /// <param name = "meta">扩展数据</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByMeta(string meta, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(meta != null ? "`Meta` = @Meta" : "`Meta` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (meta != null)
				paras_.Add(Database.CreateInParameter("@Meta", meta, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByMetaAsync(string meta, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(meta != null ? "`Meta` = @Meta" : "`Meta` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (meta != null)
				paras_.Add(Database.CreateInParameter("@Meta", meta, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByMeta
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByUserIP
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP)
		{
			return GetByUserIP(userIP, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP)
		{
			return await GetByUserIPAsync(userIP, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, TransactionManager tm_)
		{
			return GetByUserIP(userIP, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, TransactionManager tm_)
		{
			return await GetByUserIPAsync(userIP, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, int top_)
		{
			return GetByUserIP(userIP, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, int top_)
		{
			return await GetByUserIPAsync(userIP, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, int top_, TransactionManager tm_)
		{
			return GetByUserIP(userIP, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, int top_, TransactionManager tm_)
		{
			return await GetByUserIPAsync(userIP, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, string sort_)
		{
			return GetByUserIP(userIP, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, string sort_)
		{
			return await GetByUserIPAsync(userIP, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, string sort_, TransactionManager tm_)
		{
			return GetByUserIP(userIP, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, string sort_, TransactionManager tm_)
		{
			return await GetByUserIPAsync(userIP, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserIP（字段） 查询
		/// </summary>
		/// /// <param name = "userIP">充值用户ip</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserIP(string userIP, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userIP != null ? "`UserIP` = @UserIP" : "`UserIP` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userIP != null)
				paras_.Add(Database.CreateInParameter("@UserIP", userIP, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserIPAsync(string userIP, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userIP != null ? "`UserIP` = @UserIP" : "`UserIP` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userIP != null)
				paras_.Add(Database.CreateInParameter("@UserIP", userIP, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserIP
		#region GetByOwnOrderId
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId)
		{
			return GetByOwnOrderId(ownOrderId, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, int top_)
		{
			return GetByOwnOrderId(ownOrderId, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, int top_, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, string sort_)
		{
			return GetByOwnOrderId(ownOrderId, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, string sort_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, string sort_, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, string sort_, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方传给银行的订单号（transaction_id）对账使用!</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnOrderId(string ownOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByOwnOrderId
		#region GetByTransMoney
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney)
		{
			return GetByTransMoney(transMoney, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney)
		{
			return await GetByTransMoneyAsync(transMoney, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, TransactionManager tm_)
		{
			return GetByTransMoney(transMoney, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, TransactionManager tm_)
		{
			return await GetByTransMoneyAsync(transMoney, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, int top_)
		{
			return GetByTransMoney(transMoney, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, int top_)
		{
			return await GetByTransMoneyAsync(transMoney, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, int top_, TransactionManager tm_)
		{
			return GetByTransMoney(transMoney, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, int top_, TransactionManager tm_)
		{
			return await GetByTransMoneyAsync(transMoney, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, string sort_)
		{
			return GetByTransMoney(transMoney, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, string sort_)
		{
			return await GetByTransMoneyAsync(transMoney, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, string sort_, TransactionManager tm_)
		{
			return GetByTransMoney(transMoney, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, string sort_, TransactionManager tm_)
		{
			return await GetByTransMoneyAsync(transMoney, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TransMoney（字段） 查询
		/// </summary>
		/// /// <param name = "transMoney">传给银行的交易金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByTransMoney(decimal transMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TransMoney` = @TransMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByTransMoneyAsync(decimal transMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TransMoney` = @TransMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransMoney", transMoney, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByTransMoney
		#region GetByOrderMoney
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney)
		{
			return GetByOrderMoney(orderMoney, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney)
		{
			return await GetByOrderMoneyAsync(orderMoney, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, TransactionManager tm_)
		{
			return GetByOrderMoney(orderMoney, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, TransactionManager tm_)
		{
			return await GetByOrderMoneyAsync(orderMoney, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, int top_)
		{
			return GetByOrderMoney(orderMoney, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, int top_)
		{
			return await GetByOrderMoneyAsync(orderMoney, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, int top_, TransactionManager tm_)
		{
			return GetByOrderMoney(orderMoney, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, int top_, TransactionManager tm_)
		{
			return await GetByOrderMoneyAsync(orderMoney, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, string sort_)
		{
			return GetByOrderMoney(orderMoney, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, string sort_)
		{
			return await GetByOrderMoneyAsync(orderMoney, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, string sort_, TransactionManager tm_)
		{
			return GetByOrderMoney(orderMoney, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, string sort_, TransactionManager tm_)
		{
			return await GetByOrderMoneyAsync(orderMoney, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderMoney（字段） 查询
		/// </summary>
		/// /// <param name = "orderMoney">订单对账金额（单位元）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOrderMoney(decimal orderMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderMoney` = @OrderMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOrderMoneyAsync(decimal orderMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderMoney` = @OrderMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderMoney", orderMoney, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByOrderMoney
		#region GetByBankResponseTime
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime)
		{
			return GetByBankResponseTime(bankResponseTime, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, TransactionManager tm_)
		{
			return GetByBankResponseTime(bankResponseTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, TransactionManager tm_)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, int top_)
		{
			return GetByBankResponseTime(bankResponseTime, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, int top_)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, int top_, TransactionManager tm_)
		{
			return GetByBankResponseTime(bankResponseTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, int top_, TransactionManager tm_)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, string sort_)
		{
			return GetByBankResponseTime(bankResponseTime, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, string sort_)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, string sort_, TransactionManager tm_)
		{
			return GetByBankResponseTime(bankResponseTime, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, string sort_, TransactionManager tm_)
		{
			return await GetByBankResponseTimeAsync(bankResponseTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankResponseTime">银行返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankResponseTime(DateTime? bankResponseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankResponseTime.HasValue ? "`BankResponseTime` = @BankResponseTime" : "`BankResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankResponseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankResponseTime", bankResponseTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankResponseTimeAsync(DateTime? bankResponseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankResponseTime.HasValue ? "`BankResponseTime` = @BankResponseTime" : "`BankResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankResponseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankResponseTime", bankResponseTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankResponseTime
		#region GetByBankOrderId
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId)
		{
			return GetByBankOrderId(bankOrderId, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, int top_)
		{
			return GetByBankOrderId(bankOrderId, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, int top_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, int top_, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, int top_, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, string sort_)
		{
			return GetByBankOrderId(bankOrderId, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, string sort_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, string sort_, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, string sort_, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">银行订单编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankOrderId(string bankOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankOrderId != null ? "`BankOrderId` = @BankOrderId" : "`BankOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankOrderId != null)
				paras_.Add(Database.CreateInParameter("@BankOrderId", bankOrderId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankOrderIdAsync(string bankOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankOrderId != null ? "`BankOrderId` = @BankOrderId" : "`BankOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankOrderId != null)
				paras_.Add(Database.CreateInParameter("@BankOrderId", bankOrderId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankOrderId
		#region GetByBankCallbackTime
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime)
		{
			return GetByBankCallbackTime(bankCallbackTime, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, TransactionManager tm_)
		{
			return GetByBankCallbackTime(bankCallbackTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, TransactionManager tm_)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, int top_)
		{
			return GetByBankCallbackTime(bankCallbackTime, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, int top_)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, int top_, TransactionManager tm_)
		{
			return GetByBankCallbackTime(bankCallbackTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, int top_, TransactionManager tm_)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, string sort_)
		{
			return GetByBankCallbackTime(bankCallbackTime, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, string sort_)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, string sort_, TransactionManager tm_)
		{
			return GetByBankCallbackTime(bankCallbackTime, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, string sort_, TransactionManager tm_)
		{
			return await GetByBankCallbackTimeAsync(bankCallbackTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankCallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankCallbackTime">银行回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankCallbackTime(DateTime? bankCallbackTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCallbackTime.HasValue ? "`BankCallbackTime` = @BankCallbackTime" : "`BankCallbackTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCallbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankCallbackTimeAsync(DateTime? bankCallbackTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCallbackTime.HasValue ? "`BankCallbackTime` = @BankCallbackTime" : "`BankCallbackTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCallbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankCallbackTime", bankCallbackTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankCallbackTime
		#region GetByBankTime
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime)
		{
			return GetByBankTime(bankTime, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime)
		{
			return await GetByBankTimeAsync(bankTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, TransactionManager tm_)
		{
			return GetByBankTime(bankTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, TransactionManager tm_)
		{
			return await GetByBankTimeAsync(bankTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, int top_)
		{
			return GetByBankTime(bankTime, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, int top_)
		{
			return await GetByBankTimeAsync(bankTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, int top_, TransactionManager tm_)
		{
			return GetByBankTime(bankTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, int top_, TransactionManager tm_)
		{
			return await GetByBankTimeAsync(bankTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, string sort_)
		{
			return GetByBankTime(bankTime, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, string sort_)
		{
			return await GetByBankTimeAsync(bankTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, string sort_, TransactionManager tm_)
		{
			return GetByBankTime(bankTime, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, string sort_, TransactionManager tm_)
		{
			return await GetByBankTimeAsync(bankTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankTime（字段） 查询
		/// </summary>
		/// /// <param name = "bankTime">银行订单的成功时间（对账使用）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBankTime(DateTime? bankTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankTime.HasValue ? "`BankTime` = @BankTime" : "`BankTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankTime", bankTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBankTimeAsync(DateTime? bankTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankTime.HasValue ? "`BankTime` = @BankTime" : "`BankTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankTime.HasValue)
				paras_.Add(Database.CreateInParameter("@BankTime", bankTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBankTime
		#region GetByBrCode
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode)
		{
			return GetByBrCode(brCode, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode)
		{
			return await GetByBrCodeAsync(brCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, TransactionManager tm_)
		{
			return GetByBrCode(brCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, TransactionManager tm_)
		{
			return await GetByBrCodeAsync(brCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, int top_)
		{
			return GetByBrCode(brCode, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, int top_)
		{
			return await GetByBrCodeAsync(brCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, int top_, TransactionManager tm_)
		{
			return GetByBrCode(brCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, int top_, TransactionManager tm_)
		{
			return await GetByBrCodeAsync(brCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, string sort_)
		{
			return GetByBrCode(brCode, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, string sort_)
		{
			return await GetByBrCodeAsync(brCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, string sort_, TransactionManager tm_)
		{
			return GetByBrCode(brCode, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, string sort_, TransactionManager tm_)
		{
			return await GetByBrCodeAsync(brCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BrCode（字段） 查询
		/// </summary>
		/// /// <param name = "brCode">支付条形码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByBrCode(string brCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(brCode != null ? "`BrCode` = @BrCode" : "`BrCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (brCode != null)
				paras_.Add(Database.CreateInParameter("@BrCode", brCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByBrCodeAsync(string brCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(brCode != null ? "`BrCode` = @BrCode" : "`BrCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (brCode != null)
				paras_.Add(Database.CreateInParameter("@BrCode", brCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByBrCode
		#region GetByQrCode
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode)
		{
			return GetByQrCode(qrCode, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode)
		{
			return await GetByQrCodeAsync(qrCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, TransactionManager tm_)
		{
			return GetByQrCode(qrCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, TransactionManager tm_)
		{
			return await GetByQrCodeAsync(qrCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, int top_)
		{
			return GetByQrCode(qrCode, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, int top_)
		{
			return await GetByQrCodeAsync(qrCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, int top_, TransactionManager tm_)
		{
			return GetByQrCode(qrCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, int top_, TransactionManager tm_)
		{
			return await GetByQrCodeAsync(qrCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, string sort_)
		{
			return GetByQrCode(qrCode, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, string sort_)
		{
			return await GetByQrCodeAsync(qrCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, string sort_, TransactionManager tm_)
		{
			return GetByQrCode(qrCode, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, string sort_, TransactionManager tm_)
		{
			return await GetByQrCodeAsync(qrCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 QrCode（字段） 查询
		/// </summary>
		/// /// <param name = "qrCode">支付二维码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByQrCode(string qrCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(qrCode != null ? "`QrCode` = @QrCode" : "`QrCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (qrCode != null)
				paras_.Add(Database.CreateInParameter("@QrCode", qrCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByQrCodeAsync(string qrCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(qrCode != null ? "`QrCode` = @QrCode" : "`QrCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (qrCode != null)
				paras_.Add(Database.CreateInParameter("@QrCode", qrCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByQrCode
		#region GetByAmount
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount)
		{
			return GetByAmount(amount, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, int top_)
		{
			return GetByAmount(amount, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, int top_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, int top_, TransactionManager tm_)
		{
			return GetByAmount(amount, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, int top_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, string sort_)
		{
			return GetByAmount(amount, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, string sort_)
		{
			return await GetByAmountAsync(amount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, string sort_, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, string sort_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">实际数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmount(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountAsync(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAmount
		#region GetByOwnFee
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee)
		{
			return GetByOwnFee(ownFee, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee)
		{
			return await GetByOwnFeeAsync(ownFee, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, TransactionManager tm_)
		{
			return GetByOwnFee(ownFee, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, TransactionManager tm_)
		{
			return await GetByOwnFeeAsync(ownFee, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, int top_)
		{
			return GetByOwnFee(ownFee, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, int top_)
		{
			return await GetByOwnFeeAsync(ownFee, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, int top_, TransactionManager tm_)
		{
			return GetByOwnFee(ownFee, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, int top_, TransactionManager tm_)
		{
			return await GetByOwnFeeAsync(ownFee, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, string sort_)
		{
			return GetByOwnFee(ownFee, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, string sort_)
		{
			return await GetByOwnFeeAsync(ownFee, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, string sort_, TransactionManager tm_)
		{
			return GetByOwnFee(ownFee, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, string sort_, TransactionManager tm_)
		{
			return await GetByOwnFeeAsync(ownFee, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OwnFee（字段） 查询
		/// </summary>
		/// /// <param name = "ownFee">我方承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByOwnFee(decimal ownFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OwnFee` = @OwnFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByOwnFeeAsync(decimal ownFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OwnFee` = @OwnFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OwnFee", ownFee, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByOwnFee
		#region GetByUserFee
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee)
		{
			return GetByUserFee(userFee, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee)
		{
			return await GetByUserFeeAsync(userFee, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, TransactionManager tm_)
		{
			return GetByUserFee(userFee, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, TransactionManager tm_)
		{
			return await GetByUserFeeAsync(userFee, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, int top_)
		{
			return GetByUserFee(userFee, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, int top_)
		{
			return await GetByUserFeeAsync(userFee, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, int top_, TransactionManager tm_)
		{
			return GetByUserFee(userFee, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, int top_, TransactionManager tm_)
		{
			return await GetByUserFeeAsync(userFee, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, string sort_)
		{
			return GetByUserFee(userFee, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, string sort_)
		{
			return await GetByUserFeeAsync(userFee, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, string sort_, TransactionManager tm_)
		{
			return GetByUserFee(userFee, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, string sort_, TransactionManager tm_)
		{
			return await GetByUserFeeAsync(userFee, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserFee（字段） 查询
		/// </summary>
		/// /// <param name = "userFee">用户承担的手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFee(decimal userFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserFee` = @UserFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAsync(decimal userFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserFee` = @UserFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFee", userFee, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserFee
		#region GetByUserMoney
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney)
		{
			return GetByUserMoney(userMoney, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney)
		{
			return await GetByUserMoneyAsync(userMoney, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, TransactionManager tm_)
		{
			return GetByUserMoney(userMoney, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, TransactionManager tm_)
		{
			return await GetByUserMoneyAsync(userMoney, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, int top_)
		{
			return GetByUserMoney(userMoney, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, int top_)
		{
			return await GetByUserMoneyAsync(userMoney, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, int top_, TransactionManager tm_)
		{
			return GetByUserMoney(userMoney, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, int top_, TransactionManager tm_)
		{
			return await GetByUserMoneyAsync(userMoney, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, string sort_)
		{
			return GetByUserMoney(userMoney, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, string sort_)
		{
			return await GetByUserMoneyAsync(userMoney, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, string sort_, TransactionManager tm_)
		{
			return GetByUserMoney(userMoney, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, string sort_, TransactionManager tm_)
		{
			return await GetByUserMoneyAsync(userMoney, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserMoney（字段） 查询
		/// </summary>
		/// /// <param name = "userMoney">支付金额（提款金额）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserMoney(decimal userMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserMoney` = @UserMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserMoneyAsync(decimal userMoney, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserMoney` = @UserMoney", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserMoney", userMoney, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserMoney
		#region GetByEndBalance
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance)
		{
			return GetByEndBalance(endBalance, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance)
		{
			return await GetByEndBalanceAsync(endBalance, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, TransactionManager tm_)
		{
			return await GetByEndBalanceAsync(endBalance, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, int top_)
		{
			return GetByEndBalance(endBalance, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, int top_)
		{
			return await GetByEndBalanceAsync(endBalance, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, int top_, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, int top_, TransactionManager tm_)
		{
			return await GetByEndBalanceAsync(endBalance, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, string sort_)
		{
			return GetByEndBalance(endBalance, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, string sort_)
		{
			return await GetByEndBalanceAsync(endBalance, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, string sort_, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, string sort_, TransactionManager tm_)
		{
			return await GetByEndBalanceAsync(endBalance, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBalance(long endBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBalance` = @EndBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBalanceAsync(long endBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBalance` = @EndBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByEndBalance
		#region GetByAmountBonus
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus)
		{
			return GetByAmountBonus(amountBonus, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, int top_)
		{
			return GetByAmountBonus(amountBonus, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, int top_)
		{
			return await GetByAmountBonusAsync(amountBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, int top_, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, int top_, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, string sort_)
		{
			return GetByAmountBonus(amountBonus, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, string sort_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, string sort_, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, string sort_, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus实际变化数量（正负数）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByAmountBonus(long amountBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBonus` = @AmountBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByAmountBonusAsync(long amountBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBonus` = @AmountBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByAmountBonus
		#region GetByEndBonus
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus)
		{
			return GetByEndBonus(endBonus, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus)
		{
			return await GetByEndBonusAsync(endBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, int top_)
		{
			return GetByEndBonus(endBonus, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, int top_)
		{
			return await GetByEndBonusAsync(endBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, int top_, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, int top_, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, string sort_)
		{
			return GetByEndBonus(endBonus, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, string sort_)
		{
			return await GetByEndBonusAsync(endBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, string sort_, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, string sort_, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByEndBonus(long endBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBonus` = @EndBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByEndBonusAsync(long endBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBonus` = @EndBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByEndBonus
		#region GetBySettlTable
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable)
		{
			return GetBySettlTable(settlTable, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable)
		{
			return await GetBySettlTableAsync(settlTable, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, TransactionManager tm_)
		{
			return GetBySettlTable(settlTable, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, TransactionManager tm_)
		{
			return await GetBySettlTableAsync(settlTable, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, int top_)
		{
			return GetBySettlTable(settlTable, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, int top_)
		{
			return await GetBySettlTableAsync(settlTable, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, int top_, TransactionManager tm_)
		{
			return GetBySettlTable(settlTable, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, int top_, TransactionManager tm_)
		{
			return await GetBySettlTableAsync(settlTable, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, string sort_)
		{
			return GetBySettlTable(settlTable, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, string sort_)
		{
			return await GetBySettlTableAsync(settlTable, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, string sort_, TransactionManager tm_)
		{
			return GetBySettlTable(settlTable, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, string sort_, TransactionManager tm_)
		{
			return await GetBySettlTableAsync(settlTable, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SettlTable（字段） 查询
		/// </summary>
		/// /// <param name = "settlTable">结算表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlTable(string settlTable, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(settlTable != null ? "`SettlTable` = @SettlTable" : "`SettlTable` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (settlTable != null)
				paras_.Add(Database.CreateInParameter("@SettlTable", settlTable, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlTableAsync(string settlTable, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(settlTable != null ? "`SettlTable` = @SettlTable" : "`SettlTable` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (settlTable != null)
				paras_.Add(Database.CreateInParameter("@SettlTable", settlTable, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetBySettlTable
		#region GetBySettlId
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId)
		{
			return GetBySettlId(settlId, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId)
		{
			return await GetBySettlIdAsync(settlId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, TransactionManager tm_)
		{
			return GetBySettlId(settlId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, TransactionManager tm_)
		{
			return await GetBySettlIdAsync(settlId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, int top_)
		{
			return GetBySettlId(settlId, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, int top_)
		{
			return await GetBySettlIdAsync(settlId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, int top_, TransactionManager tm_)
		{
			return GetBySettlId(settlId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, int top_, TransactionManager tm_)
		{
			return await GetBySettlIdAsync(settlId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, string sort_)
		{
			return GetBySettlId(settlId, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, string sort_)
		{
			return await GetBySettlIdAsync(settlId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, string sort_, TransactionManager tm_)
		{
			return GetBySettlId(settlId, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, string sort_, TransactionManager tm_)
		{
			return await GetBySettlIdAsync(settlId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SettlId（字段） 查询
		/// </summary>
		/// /// <param name = "settlId">结算编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlId(string settlId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(settlId != null ? "`SettlId` = @SettlId" : "`SettlId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (settlId != null)
				paras_.Add(Database.CreateInParameter("@SettlId", settlId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlIdAsync(string settlId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(settlId != null ? "`SettlId` = @SettlId" : "`SettlId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (settlId != null)
				paras_.Add(Database.CreateInParameter("@SettlId", settlId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetBySettlId
		#region GetBySettlAmount
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount)
		{
			return GetBySettlAmount(settlAmount, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount)
		{
			return await GetBySettlAmountAsync(settlAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, TransactionManager tm_)
		{
			return GetBySettlAmount(settlAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, TransactionManager tm_)
		{
			return await GetBySettlAmountAsync(settlAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, int top_)
		{
			return GetBySettlAmount(settlAmount, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, int top_)
		{
			return await GetBySettlAmountAsync(settlAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, int top_, TransactionManager tm_)
		{
			return GetBySettlAmount(settlAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, int top_, TransactionManager tm_)
		{
			return await GetBySettlAmountAsync(settlAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, string sort_)
		{
			return GetBySettlAmount(settlAmount, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, string sort_)
		{
			return await GetBySettlAmountAsync(settlAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, string sort_, TransactionManager tm_)
		{
			return GetBySettlAmount(settlAmount, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, string sort_, TransactionManager tm_)
		{
			return await GetBySettlAmountAsync(settlAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SettlAmount（字段） 查询
		/// </summary>
		/// /// <param name = "settlAmount">结算金额(正负数)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlAmount(long settlAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`SettlAmount` = @SettlAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlAmountAsync(long settlAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`SettlAmount` = @SettlAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlAmount", settlAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetBySettlAmount
		#region GetBySettlStatus
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus)
		{
			return GetBySettlStatus(settlStatus, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus)
		{
			return await GetBySettlStatusAsync(settlStatus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, TransactionManager tm_)
		{
			return GetBySettlStatus(settlStatus, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, TransactionManager tm_)
		{
			return await GetBySettlStatusAsync(settlStatus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, int top_)
		{
			return GetBySettlStatus(settlStatus, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, int top_)
		{
			return await GetBySettlStatusAsync(settlStatus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, int top_, TransactionManager tm_)
		{
			return GetBySettlStatus(settlStatus, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, int top_, TransactionManager tm_)
		{
			return await GetBySettlStatusAsync(settlStatus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, string sort_)
		{
			return GetBySettlStatus(settlStatus, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, string sort_)
		{
			return await GetBySettlStatusAsync(settlStatus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, string sort_, TransactionManager tm_)
		{
			return GetBySettlStatus(settlStatus, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, string sort_, TransactionManager tm_)
		{
			return await GetBySettlStatusAsync(settlStatus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SettlStatus（字段） 查询
		/// </summary>
		/// /// <param name = "settlStatus">结算状态（0-初始 1-完全一致 2-我方初始，对方成功 3-我方成功，对方失败 4-我方失败，对方成功）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetBySettlStatus(int settlStatus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`SettlStatus` = @SettlStatus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetBySettlStatusAsync(int settlStatus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`SettlStatus` = @SettlStatus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@SettlStatus", settlStatus, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetBySettlStatus
		#region GetByCompleteFlag
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag)
		{
			return GetByCompleteFlag(completeFlag, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag)
		{
			return await GetByCompleteFlagAsync(completeFlag, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, TransactionManager tm_)
		{
			return GetByCompleteFlag(completeFlag, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, TransactionManager tm_)
		{
			return await GetByCompleteFlagAsync(completeFlag, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, int top_)
		{
			return GetByCompleteFlag(completeFlag, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, int top_)
		{
			return await GetByCompleteFlagAsync(completeFlag, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, int top_, TransactionManager tm_)
		{
			return GetByCompleteFlag(completeFlag, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, int top_, TransactionManager tm_)
		{
			return await GetByCompleteFlagAsync(completeFlag, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, string sort_)
		{
			return GetByCompleteFlag(completeFlag, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, string sort_)
		{
			return await GetByCompleteFlagAsync(completeFlag, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, string sort_, TransactionManager tm_)
		{
			return GetByCompleteFlag(completeFlag, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, string sort_, TransactionManager tm_)
		{
			return await GetByCompleteFlagAsync(completeFlag, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CompleteFlag（字段） 查询
		/// </summary>
		/// /// <param name = "completeFlag">完成标记0.三方回调完成 1.我方主动调用</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCompleteFlag(int completeFlag, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CompleteFlag` = @CompleteFlag", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCompleteFlagAsync(int completeFlag, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CompleteFlag` = @CompleteFlag", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompleteFlag", completeFlag, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByCompleteFlag
		#region GetByActivityIds
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds)
		{
			return GetByActivityIds(activityIds, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds)
		{
			return await GetByActivityIdsAsync(activityIds, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, TransactionManager tm_)
		{
			return GetByActivityIds(activityIds, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, TransactionManager tm_)
		{
			return await GetByActivityIdsAsync(activityIds, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, int top_)
		{
			return GetByActivityIds(activityIds, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, int top_)
		{
			return await GetByActivityIdsAsync(activityIds, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, int top_, TransactionManager tm_)
		{
			return GetByActivityIds(activityIds, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, int top_, TransactionManager tm_)
		{
			return await GetByActivityIdsAsync(activityIds, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, string sort_)
		{
			return GetByActivityIds(activityIds, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, string sort_)
		{
			return await GetByActivityIdsAsync(activityIds, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, string sort_, TransactionManager tm_)
		{
			return GetByActivityIds(activityIds, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, string sort_, TransactionManager tm_)
		{
			return await GetByActivityIdsAsync(activityIds, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ActivityIds（字段） 查询
		/// </summary>
		/// /// <param name = "activityIds">活动id集合|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByActivityIds(string activityIds, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(activityIds != null ? "`ActivityIds` = @ActivityIds" : "`ActivityIds` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (activityIds != null)
				paras_.Add(Database.CreateInParameter("@ActivityIds", activityIds, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByActivityIdsAsync(string activityIds, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(activityIds != null ? "`ActivityIds` = @ActivityIds" : "`ActivityIds` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (activityIds != null)
				paras_.Add(Database.CreateInParameter("@ActivityIds", activityIds, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByActivityIds
		#region GetByIsAddBalance
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance)
		{
			return GetByIsAddBalance(isAddBalance, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, TransactionManager tm_)
		{
			return GetByIsAddBalance(isAddBalance, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, TransactionManager tm_)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, int top_)
		{
			return GetByIsAddBalance(isAddBalance, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, int top_)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, int top_, TransactionManager tm_)
		{
			return GetByIsAddBalance(isAddBalance, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, int top_, TransactionManager tm_)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, string sort_)
		{
			return GetByIsAddBalance(isAddBalance, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, string sort_)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, string sort_, TransactionManager tm_)
		{
			return GetByIsAddBalance(isAddBalance, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, string sort_, TransactionManager tm_)
		{
			return await GetByIsAddBalanceAsync(isAddBalance, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsAddBalance（字段） 查询
		/// </summary>
		/// /// <param name = "isAddBalance">充值是否添加账户余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAddBalance(bool isAddBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAddBalance` = @IsAddBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAddBalanceAsync(bool isAddBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAddBalance` = @IsAddBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAddBalance", isAddBalance, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByIsAddBalance
		#region GetByIsAuditOrder
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder)
		{
			return GetByIsAuditOrder(isAuditOrder, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, TransactionManager tm_)
		{
			return GetByIsAuditOrder(isAuditOrder, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, TransactionManager tm_)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, int top_)
		{
			return GetByIsAuditOrder(isAuditOrder, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, int top_)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, int top_, TransactionManager tm_)
		{
			return GetByIsAuditOrder(isAuditOrder, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, int top_, TransactionManager tm_)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, string sort_)
		{
			return GetByIsAuditOrder(isAuditOrder, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, string sort_)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, string sort_, TransactionManager tm_)
		{
			return GetByIsAuditOrder(isAuditOrder, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, string sort_, TransactionManager tm_)
		{
			return await GetByIsAuditOrderAsync(isAuditOrder, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsAuditOrder（字段） 查询
		/// </summary>
		/// /// <param name = "isAuditOrder">是否提现审核订单</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByIsAuditOrder(bool isAuditOrder, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAuditOrder` = @IsAuditOrder", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByIsAuditOrderAsync(bool isAuditOrder, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAuditOrder` = @IsAuditOrder", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAuditOrder", isAuditOrder, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByIsAuditOrder
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, int top_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, string sort_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByUserFeeAmount
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount)
		{
			return GetByUserFeeAmount(userFeeAmount, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, TransactionManager tm_)
		{
			return GetByUserFeeAmount(userFeeAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, TransactionManager tm_)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, int top_)
		{
			return GetByUserFeeAmount(userFeeAmount, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, int top_)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, int top_, TransactionManager tm_)
		{
			return GetByUserFeeAmount(userFeeAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, int top_, TransactionManager tm_)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, string sort_)
		{
			return GetByUserFeeAmount(userFeeAmount, 0, sort_, null);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, string sort_)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, string sort_, TransactionManager tm_)
		{
			return GetByUserFeeAmount(userFeeAmount, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, string sort_, TransactionManager tm_)
		{
			return await GetByUserFeeAmountAsync(userFeeAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserFeeAmount（字段） 查询
		/// </summary>
		/// /// <param name = "userFeeAmount">我方收取的vip用户手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_orderEO> GetByUserFeeAmount(long userFeeAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserFeeAmount` = @UserFeeAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		public async Task<List<Sb_bank_orderEO>> GetByUserFeeAmountAsync(long userFeeAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserFeeAmount` = @UserFeeAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserFeeAmount", userFeeAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_orderEO.MapDataReader);
		}
		#endregion // GetByUserFeeAmount
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
