/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-04-10 14: 29:09
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
	/// 提款审核
	/// 【表 sc_cash_audit 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_auditEO : IRowMapper<Sc_cash_auditEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_auditEO()
		{
			this.UserKind = 1;
			this.FromMode = 0;
			this.Amount = 0;
			this.CashRate = 0.00f;
			this.Channels = 0;
			this.Status = 0;
			this.ApplyTime = DateTime.Now;
			this.Paytype = 0;
			this.Channel = 0;
			this.IsAudit = true;
			this.AmountBalance = 0;
			this.AmountBonus = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalCashAuditID;
		/// <summary>
		/// 【数据库中的原始主键 CashAuditID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalCashAuditID
		{
			get { return _originalCashAuditID; }
			set { HasOriginal = true; _originalCashAuditID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "CashAuditID", CashAuditID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 主键guid
		/// 【主键 varchar(36)】
		/// </summary>
		[DataMember(Order = 1)]
		public string CashAuditID { get; set; }
		/// <summary>
		/// 用户编码(GUID)
		/// 【字段 varchar(36)】
		/// </summary>
		[DataMember(Order = 2)]
		public string UserID { get; set; }
		/// <summary>
		/// 用户类型
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 3)]
		public int UserKind { get; set; }
		/// <summary>
		/// 新用户来源方式
		///              0-获得运营商的新用户(s_operator)
		///              1-推广员获得的新用户（userid）
		///              2-推广渠道通过url获得的新用户（s_channel_url)
		///              3-推广渠道通过code获得的新用户（s_channel_code)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 4)]
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
		[DataMember(Order = 5)]
		public string FromId { get; set; }
		/// <summary>
		/// AppId
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 6)]
		public string AppID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 7)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 8)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币类型
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 9)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 手机号
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 10)]
		public string Mobile { get; set; }
		/// <summary>
		/// 提款金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 11)]
		public long Amount { get; set; }
		/// <summary>
		/// 提现手续费率
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 12)]
		public float CashRate { get; set; }
		/// <summary>
		/// 银行代码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 13)]
		public string BankCode { get; set; }
		/// <summary>
		/// 银行名称
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 14)]
		public string BankName { get; set; }
		/// <summary>
		/// 用户账户名称
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 15)]
		public string AccName { get; set; }
		/// <summary>
		/// 用户账号（银行卡号等）
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 16)]
		public string AccNumber { get; set; }
		/// <summary>
		/// 提款渠道0-银行卡
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 17)]
		public int Channels { get; set; }
		/// <summary>
		/// 提款审核状态0-处理中1-通过2-拒绝
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 18)]
		public int Status { get; set; }
		/// <summary>
		/// 申请时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 19)]
		public DateTime ApplyTime { get; set; }
		/// <summary>
		/// 审批时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 20)]
		public DateTime? AuditTime { get; set; }
		/// <summary>
		/// 审批人
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 21)]
		public string OperatorUser { get; set; }
		/// <summary>
		/// BankId
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 22)]
		public string BankID { get; set; }
		/// <summary>
		/// paytype(1.visa,2.spei3.mongopay4.pandapay)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 23)]
		public int Paytype { get; set; }
		/// <summary>
		/// bankid对应支持的渠道编码
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 24)]
		public int Channel { get; set; }
		/// <summary>
		/// 请求参数
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 25)]
		public string RequestParam { get; set; }
		/// <summary>
		/// 备注
		/// 【字段 varchar(200)】
		/// </summary>
		[DataMember(Order = 26)]
		public string Remark { get; set; }
		/// <summary>
		/// 是否需要审核
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 27)]
		public bool IsAudit { get; set; }
		/// <summary>
		/// balance变化额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 28)]
		public long AmountBalance { get; set; }
		/// <summary>
		/// bonus变化额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 29)]
		public long AmountBonus { get; set; }
		/// <summary>
		/// sb_bank_order表中Orderid
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 30)]
		public string BankOrderId { get; set; }
		/// <summary>
		/// 返回时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 31)]
		public DateTime? RequestTime { get; set; }
		/// <summary>
		/// 返回时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 32)]
		public DateTime? ResponseTime { get; set; }
		/// <summary>
		/// 回调时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 33)]
		public DateTime? CallbackTime { get; set; }
		/// <summary>
		/// 原因
		/// 【字段 varchar(255)】
		/// </summary>
		[DataMember(Order = 34)]
		public string Reason { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_auditEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_auditEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_auditEO ret = new Sc_cash_auditEO();
			ret.CashAuditID = reader.ToString("CashAuditID");
			ret.OriginalCashAuditID = ret.CashAuditID;
			ret.UserID = reader.ToString("UserID");
			ret.UserKind = reader.ToInt32("UserKind");
			ret.FromMode = reader.ToInt32("FromMode");
			ret.FromId = reader.ToString("FromId");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.Mobile = reader.ToString("Mobile");
			ret.Amount = reader.ToInt64("Amount");
			ret.CashRate = reader.ToSingle("CashRate");
			ret.BankCode = reader.ToString("BankCode");
			ret.BankName = reader.ToString("BankName");
			ret.AccName = reader.ToString("AccName");
			ret.AccNumber = reader.ToString("AccNumber");
			ret.Channels = reader.ToInt32("Channels");
			ret.Status = reader.ToInt32("Status");
			ret.ApplyTime = reader.ToDateTime("ApplyTime");
			ret.AuditTime = reader.ToDateTimeN("AuditTime");
			ret.OperatorUser = reader.ToString("OperatorUser");
			ret.BankID = reader.ToString("BankID");
			ret.Paytype = reader.ToInt32("Paytype");
			ret.Channel = reader.ToInt32("Channel");
			ret.RequestParam = reader.ToString("RequestParam");
			ret.Remark = reader.ToString("Remark");
			ret.IsAudit = reader.ToBoolean("IsAudit");
			ret.AmountBalance = reader.ToInt64("AmountBalance");
			ret.AmountBonus = reader.ToInt64("AmountBonus");
			ret.BankOrderId = reader.ToString("BankOrderId");
			ret.RequestTime = reader.ToDateTimeN("RequestTime");
			ret.ResponseTime = reader.ToDateTimeN("ResponseTime");
			ret.CallbackTime = reader.ToDateTimeN("CallbackTime");
			ret.Reason = reader.ToString("Reason");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 提款审核
	/// 【表 sc_cash_audit 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_auditMO : MySqlTableMO<Sc_cash_auditEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_audit`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_auditMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_auditMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_auditMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_auditEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_cash_auditEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_cash_auditEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`CashAuditID`, `UserID`, `UserKind`, `FromMode`, `FromId`, `AppID`, `OperatorID`, `CountryID`, `CurrencyID`, `Mobile`, `Amount`, `CashRate`, `BankCode`, `BankName`, `AccName`, `AccNumber`, `Channels`, `Status`, `ApplyTime`, `AuditTime`, `OperatorUser`, `BankID`, `Paytype`, `Channel`, `RequestParam`, `Remark`, `IsAudit`, `AmountBalance`, `AmountBonus`, `BankOrderId`, `RequestTime`, `ResponseTime`, `CallbackTime`, `Reason`) VALUE (@CashAuditID, @UserID, @UserKind, @FromMode, @FromId, @AppID, @OperatorID, @CountryID, @CurrencyID, @Mobile, @Amount, @CashRate, @BankCode, @BankName, @AccName, @AccNumber, @Channels, @Status, @ApplyTime, @AuditTime, @OperatorUser, @BankID, @Paytype, @Channel, @RequestParam, @Remark, @IsAudit, @AmountBalance, @AmountBonus, @BankOrderId, @RequestTime, @ResponseTime, @CallbackTime, @Reason);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", item.CashAuditID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Mobile", item.Mobile != null ? item.Mobile : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashRate", item.CashRate, MySqlDbType.Float),
				Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccName", item.AccName != null ? item.AccName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccNumber", item.AccNumber, MySqlDbType.VarChar),
				Database.CreateInParameter("@Channels", item.Channels, MySqlDbType.Int32),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@ApplyTime", item.ApplyTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@AuditTime", item.AuditTime.HasValue ? item.AuditTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorUser", item.OperatorUser != null ? item.OperatorUser : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID", item.BankID != null ? item.BankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Paytype", item.Paytype, MySqlDbType.Int32),
				Database.CreateInParameter("@Channel", item.Channel, MySqlDbType.Int32),
				Database.CreateInParameter("@RequestParam", item.RequestParam != null ? item.RequestParam : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Remark", item.Remark != null ? item.Remark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsAudit", item.IsAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@AmountBalance", item.AmountBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@AmountBonus", item.AmountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@BankOrderId", item.BankOrderId != null ? item.BankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RequestTime", item.RequestTime.HasValue ? item.RequestTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@ResponseTime", item.ResponseTime.HasValue ? item.ResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CallbackTime", item.CallbackTime.HasValue ? item.CallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@Reason", item.Reason != null ? item.Reason : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_auditEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_auditEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_auditEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`CashAuditID`, `UserID`, `UserKind`, `FromMode`, `FromId`, `AppID`, `OperatorID`, `CountryID`, `CurrencyID`, `Mobile`, `Amount`, `CashRate`, `BankCode`, `BankName`, `AccName`, `AccNumber`, `Channels`, `Status`, `ApplyTime`, `AuditTime`, `OperatorUser`, `BankID`, `Paytype`, `Channel`, `RequestParam`, `Remark`, `IsAudit`, `AmountBalance`, `AmountBonus`, `BankOrderId`, `RequestTime`, `ResponseTime`, `CallbackTime`, `Reason`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.CashAuditID}','{item.UserID}',{item.UserKind},{item.FromMode},'{item.FromId}','{item.AppID}','{item.OperatorID}','{item.CountryID}','{item.CurrencyID}','{item.Mobile}',{item.Amount},{item.CashRate},'{item.BankCode}','{item.BankName}','{item.AccName}','{item.AccNumber}',{item.Channels},{item.Status},'{item.ApplyTime.ToString("yyyy-MM-dd HH:mm:ss")}','{item.AuditTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.OperatorUser}','{item.BankID}',{item.Paytype},{item.Channel},'{item.RequestParam}','{item.Remark}',{item.IsAudit},{item.AmountBalance},{item.AmountBonus},'{item.BankOrderId}','{item.RequestTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.ResponseTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.CallbackTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.Reason}'),");
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string cashAuditID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_auditEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.CashAuditID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_auditEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.CashAuditID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
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
		#region RemoveByAppID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appID">AppId</param>
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
		#region RemoveByCurrencyID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
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
		#region RemoveByMobile
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByMobile(string mobile, TransactionManager tm_ = null)
		{
			RepairRemoveByMobileData(mobile, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByMobileAsync(string mobile, TransactionManager tm_ = null)
		{
			RepairRemoveByMobileData(mobile, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByMobileData(string mobile, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (mobile != null ? "`Mobile` = @Mobile" : "`Mobile` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (mobile != null)
				paras_.Add(Database.CreateInParameter("@Mobile", mobile, MySqlDbType.VarChar));
		}
		#endregion // RemoveByMobile
		#region RemoveByAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
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
		#region RemoveByCashRate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashRate(float cashRate, TransactionManager tm_ = null)
		{
			RepairRemoveByCashRateData(cashRate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashRateAsync(float cashRate, TransactionManager tm_ = null)
		{
			RepairRemoveByCashRateData(cashRate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashRateData(float cashRate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashRate` = @CashRate";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float));
		}
		#endregion // RemoveByCashRate
		#region RemoveByBankCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
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
		#region RemoveByBankName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankName(string bankName, TransactionManager tm_ = null)
		{
			RepairRemoveByBankNameData(bankName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankNameAsync(string bankName, TransactionManager tm_ = null)
		{
			RepairRemoveByBankNameData(bankName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankNameData(string bankName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBankName
		#region RemoveByAccName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
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
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
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
			sql_ = $"DELETE FROM {TableName} WHERE `AccNumber` = @AccNumber";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAccNumber
		#region RemoveByChannels
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByChannels(int channels, TransactionManager tm_ = null)
		{
			RepairRemoveByChannelsData(channels, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByChannelsAsync(int channels, TransactionManager tm_ = null)
		{
			RepairRemoveByChannelsData(channels, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByChannelsData(int channels, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Channels` = @Channels";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32));
		}
		#endregion // RemoveByChannels
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
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
		#region RemoveByApplyTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByApplyTime(DateTime applyTime, TransactionManager tm_ = null)
		{
			RepairRemoveByApplyTimeData(applyTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByApplyTimeAsync(DateTime applyTime, TransactionManager tm_ = null)
		{
			RepairRemoveByApplyTimeData(applyTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByApplyTimeData(DateTime applyTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ApplyTime` = @ApplyTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime));
		}
		#endregion // RemoveByApplyTime
		#region RemoveByAuditTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAuditTime(DateTime? auditTime, TransactionManager tm_ = null)
		{
			RepairRemoveByAuditTimeData(auditTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAuditTimeAsync(DateTime? auditTime, TransactionManager tm_ = null)
		{
			RepairRemoveByAuditTimeData(auditTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAuditTimeData(DateTime? auditTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (auditTime.HasValue ? "`AuditTime` = @AuditTime" : "`AuditTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (auditTime.HasValue)
				paras_.Add(Database.CreateInParameter("@AuditTime", auditTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByAuditTime
		#region RemoveByOperatorUser
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperatorUser(string operatorUser, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorUserData(operatorUser, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOperatorUserAsync(string operatorUser, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorUserData(operatorUser, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOperatorUserData(string operatorUser, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (operatorUser != null ? "`OperatorUser` = @OperatorUser" : "`OperatorUser` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (operatorUser != null)
				paras_.Add(Database.CreateInParameter("@OperatorUser", operatorUser, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOperatorUser
		#region RemoveByBankID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
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
		#region RemoveByPaytype
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPaytype(int paytype, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeData(paytype, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPaytypeAsync(int paytype, TransactionManager tm_ = null)
		{
			RepairRemoveByPaytypeData(paytype, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPaytypeData(int paytype, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Paytype` = @Paytype";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32));
		}
		#endregion // RemoveByPaytype
		#region RemoveByChannel
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByChannel(int channel, TransactionManager tm_ = null)
		{
			RepairRemoveByChannelData(channel, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByChannelAsync(int channel, TransactionManager tm_ = null)
		{
			RepairRemoveByChannelData(channel, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByChannelData(int channel, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Channel` = @Channel";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32));
		}
		#endregion // RemoveByChannel
		#region RemoveByRequestParam
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRequestParam(string requestParam, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestParamData(requestParam, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRequestParamAsync(string requestParam, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestParamData(requestParam, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRequestParamData(string requestParam, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (requestParam != null ? "`RequestParam` = @RequestParam" : "`RequestParam` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (requestParam != null)
				paras_.Add(Database.CreateInParameter("@RequestParam", requestParam, MySqlDbType.Text));
		}
		#endregion // RemoveByRequestParam
		#region RemoveByRemark
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRemark(string remark, TransactionManager tm_ = null)
		{
			RepairRemoveByRemarkData(remark, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRemarkAsync(string remark, TransactionManager tm_ = null)
		{
			RepairRemoveByRemarkData(remark, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRemarkData(string remark, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (remark != null ? "`Remark` = @Remark" : "`Remark` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (remark != null)
				paras_.Add(Database.CreateInParameter("@Remark", remark, MySqlDbType.VarChar));
		}
		#endregion // RemoveByRemark
		#region RemoveByIsAudit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsAudit(bool isAudit, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditData(isAudit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsAuditAsync(bool isAudit, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditData(isAudit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsAuditData(bool isAudit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsAudit` = @IsAudit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsAudit
		#region RemoveByAmountBalance
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAmountBalance(long amountBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountBalanceData(amountBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAmountBalanceAsync(long amountBalance, TransactionManager tm_ = null)
		{
			RepairRemoveByAmountBalanceData(amountBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAmountBalanceData(long amountBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AmountBalance` = @AmountBalance";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64));
		}
		#endregion // RemoveByAmountBalance
		#region RemoveByAmountBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
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
		#region RemoveByBankOrderId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
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
		#region RemoveByRequestTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRequestTime(DateTime? requestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestTimeData(requestTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRequestTimeAsync(DateTime? requestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestTimeData(requestTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRequestTimeData(DateTime? requestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (requestTime.HasValue ? "`RequestTime` = @RequestTime" : "`RequestTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (requestTime.HasValue)
				paras_.Add(Database.CreateInParameter("@RequestTime", requestTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByRequestTime
		#region RemoveByResponseTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByResponseTime(DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairRemoveByResponseTimeData(responseTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByResponseTimeAsync(DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairRemoveByResponseTimeData(responseTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByResponseTimeData(DateTime? responseTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (responseTime.HasValue ? "`ResponseTime` = @ResponseTime" : "`ResponseTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (responseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@ResponseTime", responseTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByResponseTime
		#region RemoveByCallbackTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCallbackTime(DateTime? callbackTime, TransactionManager tm_ = null)
		{
			RepairRemoveByCallbackTimeData(callbackTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCallbackTimeAsync(DateTime? callbackTime, TransactionManager tm_ = null)
		{
			RepairRemoveByCallbackTimeData(callbackTime.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCallbackTimeData(DateTime? callbackTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (callbackTime.HasValue ? "`CallbackTime` = @CallbackTime" : "`CallbackTime` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (callbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@CallbackTime", callbackTime.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByCallbackTime
		#region RemoveByReason
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByReason(string reason, TransactionManager tm_ = null)
		{
			RepairRemoveByReasonData(reason, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByReasonAsync(string reason, TransactionManager tm_ = null)
		{
			RepairRemoveByReasonData(reason, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByReasonData(string reason, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (reason != null ? "`Reason` = @Reason" : "`Reason` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (reason != null)
				paras_.Add(Database.CreateInParameter("@Reason", reason, MySqlDbType.VarChar));
		}
		#endregion // RemoveByReason
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
		public int Put(Sc_cash_auditEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_auditEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_auditEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashAuditID` = @CashAuditID, `UserID` = @UserID, `UserKind` = @UserKind, `FromMode` = @FromMode, `FromId` = @FromId, `AppID` = @AppID, `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `Mobile` = @Mobile, `Amount` = @Amount, `CashRate` = @CashRate, `BankCode` = @BankCode, `BankName` = @BankName, `AccName` = @AccName, `AccNumber` = @AccNumber, `Channels` = @Channels, `Status` = @Status, `AuditTime` = @AuditTime, `OperatorUser` = @OperatorUser, `BankID` = @BankID, `Paytype` = @Paytype, `Channel` = @Channel, `RequestParam` = @RequestParam, `Remark` = @Remark, `IsAudit` = @IsAudit, `AmountBalance` = @AmountBalance, `AmountBonus` = @AmountBonus, `BankOrderId` = @BankOrderId, `RequestTime` = @RequestTime, `ResponseTime` = @ResponseTime, `CallbackTime` = @CallbackTime, `Reason` = @Reason WHERE `CashAuditID` = @CashAuditID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", item.CashAuditID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Mobile", item.Mobile != null ? item.Mobile : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Amount", item.Amount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashRate", item.CashRate, MySqlDbType.Float),
				Database.CreateInParameter("@BankCode", item.BankCode != null ? item.BankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccName", item.AccName != null ? item.AccName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AccNumber", item.AccNumber, MySqlDbType.VarChar),
				Database.CreateInParameter("@Channels", item.Channels, MySqlDbType.Int32),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@AuditTime", item.AuditTime.HasValue ? item.AuditTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorUser", item.OperatorUser != null ? item.OperatorUser : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID", item.BankID != null ? item.BankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Paytype", item.Paytype, MySqlDbType.Int32),
				Database.CreateInParameter("@Channel", item.Channel, MySqlDbType.Int32),
				Database.CreateInParameter("@RequestParam", item.RequestParam != null ? item.RequestParam : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Remark", item.Remark != null ? item.Remark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsAudit", item.IsAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@AmountBalance", item.AmountBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@AmountBonus", item.AmountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@BankOrderId", item.BankOrderId != null ? item.BankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RequestTime", item.RequestTime.HasValue ? item.RequestTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@ResponseTime", item.ResponseTime.HasValue ? item.ResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CallbackTime", item.CallbackTime.HasValue ? item.CallbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@Reason", item.Reason != null ? item.Reason : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID_Original", item.HasOriginal ? item.OriginalCashAuditID : item.CashAuditID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_auditEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_auditEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string cashAuditID, string set_, params object[] values_)
		{
			return Put(set_, "`CashAuditID` = @CashAuditID", ConcatValues(values_, cashAuditID));
		}
		public async Task<int> PutByPKAsync(string cashAuditID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`CashAuditID` = @CashAuditID", ConcatValues(values_, cashAuditID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string cashAuditID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`CashAuditID` = @CashAuditID", tm_, ConcatValues(values_, cashAuditID));
		}
		public async Task<int> PutByPKAsync(string cashAuditID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`CashAuditID` = @CashAuditID", tm_, ConcatValues(values_, cashAuditID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string cashAuditID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`CashAuditID` = @CashAuditID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string cashAuditID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`CashAuditID` = @CashAuditID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIDByPK(string cashAuditID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(cashAuditID, userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIDByPKAsync(string cashAuditID, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(cashAuditID, userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIDByPKData(string cashAuditID, string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		#region PutUserKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserKindByPK(string cashAuditID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(cashAuditID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserKindByPKAsync(string cashAuditID, int userKind, TransactionManager tm_ = null)
		{
			RepairPutUserKindByPKData(cashAuditID, userKind, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserKindByPKData(string cashAuditID, int userKind, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserKind` = @UserKind  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		#region PutFromMode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromModeByPK(string cashAuditID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(cashAuditID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromModeByPKAsync(string cashAuditID, int fromMode, TransactionManager tm_ = null)
		{
			RepairPutFromModeByPKData(cashAuditID, fromMode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromModeByPKData(string cashAuditID, int fromMode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromMode` = @FromMode  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFromIdByPK(string cashAuditID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(cashAuditID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFromIdByPKAsync(string cashAuditID, string fromId, TransactionManager tm_ = null)
		{
			RepairPutFromIdByPKData(cashAuditID, fromId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFromIdByPKData(string cashAuditID, string fromId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FromId` = @FromId  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FromId", fromId != null ? fromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		#region PutAppID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "appID">AppId</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppIDByPK(string cashAuditID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(cashAuditID, appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppIDByPKAsync(string cashAuditID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(cashAuditID, appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppIDByPKData(string cashAuditID, string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppID` = @AppID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appID">AppId</param>
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(string cashAuditID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(cashAuditID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(string cashAuditID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(cashAuditID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(string cashAuditID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		#region PutCountryID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(string cashAuditID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(cashAuditID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(string cashAuditID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(cashAuditID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(string cashAuditID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
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
		#region PutCurrencyID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(string cashAuditID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(cashAuditID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(string cashAuditID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(cashAuditID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(string cashAuditID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
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
		#region PutMobile
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "mobile">手机号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMobileByPK(string cashAuditID, string mobile, TransactionManager tm_ = null)
		{
			RepairPutMobileByPKData(cashAuditID, mobile, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutMobileByPKAsync(string cashAuditID, string mobile, TransactionManager tm_ = null)
		{
			RepairPutMobileByPKData(cashAuditID, mobile, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutMobileByPKData(string cashAuditID, string mobile, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Mobile` = @Mobile  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Mobile", mobile != null ? mobile : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutMobile(string mobile, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Mobile` = @Mobile";
			var parameter_ = Database.CreateInParameter("@Mobile", mobile != null ? mobile : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutMobileAsync(string mobile, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Mobile` = @Mobile";
			var parameter_ = Database.CreateInParameter("@Mobile", mobile != null ? mobile : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutMobile
		#region PutAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "amount">提款金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountByPK(string cashAuditID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(cashAuditID, amount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountByPKAsync(string cashAuditID, long amount, TransactionManager tm_ = null)
		{
			RepairPutAmountByPKData(cashAuditID, amount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountByPKData(string cashAuditID, long amount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Amount` = @Amount  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
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
		#region PutCashRate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashRateByPK(string cashAuditID, float cashRate, TransactionManager tm_ = null)
		{
			RepairPutCashRateByPKData(cashAuditID, cashRate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashRateByPKAsync(string cashAuditID, float cashRate, TransactionManager tm_ = null)
		{
			RepairPutCashRateByPKData(cashAuditID, cashRate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashRateByPKData(string cashAuditID, float cashRate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashRate` = @CashRate  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashRate(float cashRate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashRate` = @CashRate";
			var parameter_ = Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashRateAsync(float cashRate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashRate` = @CashRate";
			var parameter_ = Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashRate
		#region PutBankCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCodeByPK(string cashAuditID, string bankCode, TransactionManager tm_ = null)
		{
			RepairPutBankCodeByPKData(cashAuditID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankCodeByPKAsync(string cashAuditID, string bankCode, TransactionManager tm_ = null)
		{
			RepairPutBankCodeByPKData(cashAuditID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankCodeByPKData(string cashAuditID, string bankCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode != null ? bankCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
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
		#region PutBankName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankNameByPK(string cashAuditID, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(cashAuditID, bankName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankNameByPKAsync(string cashAuditID, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(cashAuditID, bankName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankNameByPKData(string cashAuditID, string bankName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankName` = @BankName  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankName(string bankName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankName` = @BankName";
			var parameter_ = Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankNameAsync(string bankName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankName` = @BankName";
			var parameter_ = Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankName
		#region PutAccName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNameByPK(string cashAuditID, string accName, TransactionManager tm_ = null)
		{
			RepairPutAccNameByPKData(cashAuditID, accName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAccNameByPKAsync(string cashAuditID, string accName, TransactionManager tm_ = null)
		{
			RepairPutAccNameByPKData(cashAuditID, accName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAccNameByPKData(string cashAuditID, string accName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AccName` = @AccName  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AccName", accName != null ? accName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNumberByPK(string cashAuditID, string accNumber, TransactionManager tm_ = null)
		{
			RepairPutAccNumberByPKData(cashAuditID, accNumber, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAccNumberByPKAsync(string cashAuditID, string accNumber, TransactionManager tm_ = null)
		{
			RepairPutAccNumberByPKData(cashAuditID, accNumber, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAccNumberByPKData(string cashAuditID, string accNumber, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAccNumber(string accNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber";
			var parameter_ = Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAccNumberAsync(string accNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AccNumber` = @AccNumber";
			var parameter_ = Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAccNumber
		#region PutChannels
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutChannelsByPK(string cashAuditID, int channels, TransactionManager tm_ = null)
		{
			RepairPutChannelsByPKData(cashAuditID, channels, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutChannelsByPKAsync(string cashAuditID, int channels, TransactionManager tm_ = null)
		{
			RepairPutChannelsByPKData(cashAuditID, channels, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutChannelsByPKData(string cashAuditID, int channels, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Channels` = @Channels  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutChannels(int channels, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Channels` = @Channels";
			var parameter_ = Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutChannelsAsync(int channels, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Channels` = @Channels";
			var parameter_ = Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutChannels
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string cashAuditID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(cashAuditID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string cashAuditID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(cashAuditID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string cashAuditID, int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
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
		#region PutApplyTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutApplyTimeByPK(string cashAuditID, DateTime applyTime, TransactionManager tm_ = null)
		{
			RepairPutApplyTimeByPKData(cashAuditID, applyTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutApplyTimeByPKAsync(string cashAuditID, DateTime applyTime, TransactionManager tm_ = null)
		{
			RepairPutApplyTimeByPKData(cashAuditID, applyTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutApplyTimeByPKData(string cashAuditID, DateTime applyTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ApplyTime` = @ApplyTime  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutApplyTime(DateTime applyTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ApplyTime` = @ApplyTime";
			var parameter_ = Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutApplyTimeAsync(DateTime applyTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ApplyTime` = @ApplyTime";
			var parameter_ = Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutApplyTime
		#region PutAuditTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAuditTimeByPK(string cashAuditID, DateTime? auditTime, TransactionManager tm_ = null)
		{
			RepairPutAuditTimeByPKData(cashAuditID, auditTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAuditTimeByPKAsync(string cashAuditID, DateTime? auditTime, TransactionManager tm_ = null)
		{
			RepairPutAuditTimeByPKData(cashAuditID, auditTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAuditTimeByPKData(string cashAuditID, DateTime? auditTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AuditTime` = @AuditTime  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditTime", auditTime.HasValue ? auditTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAuditTime(DateTime? auditTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AuditTime` = @AuditTime";
			var parameter_ = Database.CreateInParameter("@AuditTime", auditTime.HasValue ? auditTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAuditTimeAsync(DateTime? auditTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AuditTime` = @AuditTime";
			var parameter_ = Database.CreateInParameter("@AuditTime", auditTime.HasValue ? auditTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAuditTime
		#region PutOperatorUser
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorUserByPK(string cashAuditID, string operatorUser, TransactionManager tm_ = null)
		{
			RepairPutOperatorUserByPKData(cashAuditID, operatorUser, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorUserByPKAsync(string cashAuditID, string operatorUser, TransactionManager tm_ = null)
		{
			RepairPutOperatorUserByPKData(cashAuditID, operatorUser, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorUserByPKData(string cashAuditID, string operatorUser, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorUser` = @OperatorUser  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorUser", operatorUser != null ? operatorUser : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorUser(string operatorUser, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorUser` = @OperatorUser";
			var parameter_ = Database.CreateInParameter("@OperatorUser", operatorUser != null ? operatorUser : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorUserAsync(string operatorUser, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorUser` = @OperatorUser";
			var parameter_ = Database.CreateInParameter("@OperatorUser", operatorUser != null ? operatorUser : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorUser
		#region PutBankID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "bankID">BankId</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankIDByPK(string cashAuditID, string bankID, TransactionManager tm_ = null)
		{
			RepairPutBankIDByPKData(cashAuditID, bankID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankIDByPKAsync(string cashAuditID, string bankID, TransactionManager tm_ = null)
		{
			RepairPutBankIDByPKData(cashAuditID, bankID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankIDByPKData(string cashAuditID, string bankID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankID` = @BankID  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID != null ? bankID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
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
		#region PutPaytype
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytypeByPK(string cashAuditID, int paytype, TransactionManager tm_ = null)
		{
			RepairPutPaytypeByPKData(cashAuditID, paytype, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPaytypeByPKAsync(string cashAuditID, int paytype, TransactionManager tm_ = null)
		{
			RepairPutPaytypeByPKData(cashAuditID, paytype, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPaytypeByPKData(string cashAuditID, int paytype, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Paytype` = @Paytype  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPaytype(int paytype, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Paytype` = @Paytype";
			var parameter_ = Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPaytypeAsync(int paytype, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Paytype` = @Paytype";
			var parameter_ = Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPaytype
		#region PutChannel
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutChannelByPK(string cashAuditID, int channel, TransactionManager tm_ = null)
		{
			RepairPutChannelByPKData(cashAuditID, channel, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutChannelByPKAsync(string cashAuditID, int channel, TransactionManager tm_ = null)
		{
			RepairPutChannelByPKData(cashAuditID, channel, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutChannelByPKData(string cashAuditID, int channel, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Channel` = @Channel  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutChannel(int channel, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Channel` = @Channel";
			var parameter_ = Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutChannelAsync(int channel, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Channel` = @Channel";
			var parameter_ = Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutChannel
		#region PutRequestParam
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestParamByPK(string cashAuditID, string requestParam, TransactionManager tm_ = null)
		{
			RepairPutRequestParamByPKData(cashAuditID, requestParam, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRequestParamByPKAsync(string cashAuditID, string requestParam, TransactionManager tm_ = null)
		{
			RepairPutRequestParamByPKData(cashAuditID, requestParam, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRequestParamByPKData(string cashAuditID, string requestParam, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RequestParam` = @RequestParam  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RequestParam", requestParam != null ? requestParam : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestParam(string requestParam, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestParam` = @RequestParam";
			var parameter_ = Database.CreateInParameter("@RequestParam", requestParam != null ? requestParam : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRequestParamAsync(string requestParam, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestParam` = @RequestParam";
			var parameter_ = Database.CreateInParameter("@RequestParam", requestParam != null ? requestParam : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRequestParam
		#region PutRemark
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "remark">备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemarkByPK(string cashAuditID, string remark, TransactionManager tm_ = null)
		{
			RepairPutRemarkByPKData(cashAuditID, remark, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRemarkByPKAsync(string cashAuditID, string remark, TransactionManager tm_ = null)
		{
			RepairPutRemarkByPKData(cashAuditID, remark, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRemarkByPKData(string cashAuditID, string remark, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Remark` = @Remark  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Remark", remark != null ? remark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRemark(string remark, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Remark` = @Remark";
			var parameter_ = Database.CreateInParameter("@Remark", remark != null ? remark : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRemarkAsync(string remark, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Remark` = @Remark";
			var parameter_ = Database.CreateInParameter("@Remark", remark != null ? remark : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRemark
		#region PutIsAudit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAuditByPK(string cashAuditID, bool isAudit, TransactionManager tm_ = null)
		{
			RepairPutIsAuditByPKData(cashAuditID, isAudit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsAuditByPKAsync(string cashAuditID, bool isAudit, TransactionManager tm_ = null)
		{
			RepairPutIsAuditByPKData(cashAuditID, isAudit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsAuditByPKData(string cashAuditID, bool isAudit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAudit(bool isAudit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit";
			var parameter_ = Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsAuditAsync(bool isAudit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit";
			var parameter_ = Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsAudit
		#region PutAmountBalance
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountBalanceByPK(string cashAuditID, long amountBalance, TransactionManager tm_ = null)
		{
			RepairPutAmountBalanceByPKData(cashAuditID, amountBalance, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountBalanceByPKAsync(string cashAuditID, long amountBalance, TransactionManager tm_ = null)
		{
			RepairPutAmountBalanceByPKData(cashAuditID, amountBalance, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountBalanceByPKData(string cashAuditID, long amountBalance, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AmountBalance` = @AmountBalance  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountBalance(long amountBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AmountBalance` = @AmountBalance";
			var parameter_ = Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAmountBalanceAsync(long amountBalance, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AmountBalance` = @AmountBalance";
			var parameter_ = Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAmountBalance
		#region PutAmountBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAmountBonusByPK(string cashAuditID, long amountBonus, TransactionManager tm_ = null)
		{
			RepairPutAmountBonusByPKData(cashAuditID, amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAmountBonusByPKAsync(string cashAuditID, long amountBonus, TransactionManager tm_ = null)
		{
			RepairPutAmountBonusByPKData(cashAuditID, amountBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAmountBonusByPKData(string cashAuditID, long amountBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AmountBonus` = @AmountBonus  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
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
		#region PutBankOrderId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankOrderIdByPK(string cashAuditID, string bankOrderId, TransactionManager tm_ = null)
		{
			RepairPutBankOrderIdByPKData(cashAuditID, bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankOrderIdByPKAsync(string cashAuditID, string bankOrderId, TransactionManager tm_ = null)
		{
			RepairPutBankOrderIdByPKData(cashAuditID, bankOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankOrderIdByPKData(string cashAuditID, string bankOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankOrderId` = @BankOrderId  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankOrderId", bankOrderId != null ? bankOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
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
		#region PutRequestTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestTimeByPK(string cashAuditID, DateTime? requestTime, TransactionManager tm_ = null)
		{
			RepairPutRequestTimeByPKData(cashAuditID, requestTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRequestTimeByPKAsync(string cashAuditID, DateTime? requestTime, TransactionManager tm_ = null)
		{
			RepairPutRequestTimeByPKData(cashAuditID, requestTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRequestTimeByPKData(string cashAuditID, DateTime? requestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RequestTime", requestTime.HasValue ? requestTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestTime(DateTime? requestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime";
			var parameter_ = Database.CreateInParameter("@RequestTime", requestTime.HasValue ? requestTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRequestTimeAsync(DateTime? requestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime";
			var parameter_ = Database.CreateInParameter("@RequestTime", requestTime.HasValue ? requestTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRequestTime
		#region PutResponseTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutResponseTimeByPK(string cashAuditID, DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairPutResponseTimeByPKData(cashAuditID, responseTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutResponseTimeByPKAsync(string cashAuditID, DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairPutResponseTimeByPKData(cashAuditID, responseTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutResponseTimeByPKData(string cashAuditID, DateTime? responseTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ResponseTime` = @ResponseTime  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ResponseTime", responseTime.HasValue ? responseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutResponseTime(DateTime? responseTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ResponseTime` = @ResponseTime";
			var parameter_ = Database.CreateInParameter("@ResponseTime", responseTime.HasValue ? responseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutResponseTimeAsync(DateTime? responseTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ResponseTime` = @ResponseTime";
			var parameter_ = Database.CreateInParameter("@ResponseTime", responseTime.HasValue ? responseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutResponseTime
		#region PutCallbackTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCallbackTimeByPK(string cashAuditID, DateTime? callbackTime, TransactionManager tm_ = null)
		{
			RepairPutCallbackTimeByPKData(cashAuditID, callbackTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCallbackTimeByPKAsync(string cashAuditID, DateTime? callbackTime, TransactionManager tm_ = null)
		{
			RepairPutCallbackTimeByPKData(cashAuditID, callbackTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCallbackTimeByPKData(string cashAuditID, DateTime? callbackTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CallbackTime` = @CallbackTime  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CallbackTime", callbackTime.HasValue ? callbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCallbackTime(DateTime? callbackTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CallbackTime` = @CallbackTime";
			var parameter_ = Database.CreateInParameter("@CallbackTime", callbackTime.HasValue ? callbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCallbackTimeAsync(DateTime? callbackTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CallbackTime` = @CallbackTime";
			var parameter_ = Database.CreateInParameter("@CallbackTime", callbackTime.HasValue ? callbackTime.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCallbackTime
		#region PutReason
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// /// <param name = "reason">原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutReasonByPK(string cashAuditID, string reason, TransactionManager tm_ = null)
		{
			RepairPutReasonByPKData(cashAuditID, reason, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutReasonByPKAsync(string cashAuditID, string reason, TransactionManager tm_ = null)
		{
			RepairPutReasonByPKData(cashAuditID, reason, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutReasonByPKData(string cashAuditID, string reason, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Reason` = @Reason  WHERE `CashAuditID` = @CashAuditID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Reason", reason != null ? reason : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutReason(string reason, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Reason` = @Reason";
			var parameter_ = Database.CreateInParameter("@Reason", reason != null ? reason : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutReasonAsync(string reason, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Reason` = @Reason";
			var parameter_ = Database.CreateInParameter("@Reason", reason != null ? reason : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutReason
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_cash_auditEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.CashAuditID) == null)
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
		public async Task<bool> SetAsync(Sc_cash_auditEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.CashAuditID) == null)
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
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_auditEO GetByPK(string cashAuditID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(cashAuditID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<Sc_cash_auditEO> GetByPKAsync(string cashAuditID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(cashAuditID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		private void RepairGetByPKData(string cashAuditID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`CashAuditID` = @CashAuditID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserKind（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetUserKindByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`UserKind`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetUserKindByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`UserKind`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromMode（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetFromModeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`FromMode`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetFromModeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`FromMode`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FromId（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetFromIdByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`FromId`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetFromIdByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`FromId`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetAppIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CurrencyID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Mobile（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetMobileByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Mobile`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetMobileByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Mobile`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Amount（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`Amount`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<long> GetAmountByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`Amount`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashRate（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetCashRateByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (float)GetScalar("`CashRate`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<float> GetCashRateByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (float)await GetScalarAsync("`CashRate`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankCode（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankCodeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankCode`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetBankCodeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankCode`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankName（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankNameByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankName`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetBankNameByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankName`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AccName（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAccNameByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AccName`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetAccNameByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AccName`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AccNumber（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAccNumberByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AccNumber`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetAccNumberByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AccNumber`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Channels（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetChannelsByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Channels`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetChannelsByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Channels`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetStatusByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Status`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetStatusByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Status`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ApplyTime（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetApplyTimeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`ApplyTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<DateTime> GetApplyTimeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`ApplyTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AuditTime（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetAuditTimeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`AuditTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<DateTime?> GetAuditTimeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`AuditTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorUser（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorUserByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorUser`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetOperatorUserByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorUser`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankID（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankIDByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetBankIDByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankID`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Paytype（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetPaytypeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Paytype`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetPaytypeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Paytype`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Channel（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetChannelByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Channel`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<int> GetChannelByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Channel`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RequestParam（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetRequestParamByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`RequestParam`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetRequestParamByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`RequestParam`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Remark（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetRemarkByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Remark`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetRemarkByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Remark`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsAudit（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsAuditByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsAudit`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<bool> GetIsAuditByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsAudit`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AmountBalance（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountBalanceByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`AmountBalance`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<long> GetAmountBalanceByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`AmountBalance`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AmountBonus（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAmountBonusByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`AmountBonus`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<long> GetAmountBonusByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`AmountBonus`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankOrderId（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankOrderIdByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankOrderId`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetBankOrderIdByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankOrderId`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RequestTime（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetRequestTimeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`RequestTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<DateTime?> GetRequestTimeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`RequestTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ResponseTime（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetResponseTimeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`ResponseTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<DateTime?> GetResponseTimeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`ResponseTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CallbackTime（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetCallbackTimeByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`CallbackTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<DateTime?> GetCallbackTimeByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`CallbackTime`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Reason（字段）
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetReasonByPK(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Reason`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		public async Task<string> GetReasonByPKAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Reason`", "`CashAuditID` = @CashAuditID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, int top_)
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
		public List<Sc_cash_auditEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, string sort_)
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
		public List<Sc_cash_auditEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserID` = @UserID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByUserKind
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserKind(int userKind)
		{
			return GetByUserKind(userKind, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, int top_)
		{
			return GetByUserKind(userKind, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, int top_)
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
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, string sort_)
		{
			return GetByUserKind(userKind, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, string sort_)
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
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByUserKind
		#region GetByFromMode
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode)
		{
			return GetByFromMode(fromMode, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, int top_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, int top_)
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
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, int top_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, int top_, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, string sort_)
		{
			return GetByFromMode(fromMode, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, string sort_)
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
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, string sort_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByFromMode(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromModeAsync(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByFromMode
		#region GetByFromId
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromId(string fromId)
		{
			return GetByFromId(fromId, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromId(string fromId, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromId(string fromId, int top_)
		{
			return GetByFromId(fromId, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, int top_)
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
		public List<Sc_cash_auditEO> GetByFromId(string fromId, int top_, TransactionManager tm_)
		{
			return GetByFromId(fromId, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, int top_, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByFromId(string fromId, string sort_)
		{
			return GetByFromId(fromId, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, string sort_)
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
		public List<Sc_cash_auditEO> GetByFromId(string fromId, string sort_, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByFromId(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByFromIdAsync(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByFromId
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, int top_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, string sort_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">AppId</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_auditEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByMobile
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile)
		{
			return GetByMobile(mobile, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile)
		{
			return await GetByMobileAsync(mobile, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, TransactionManager tm_)
		{
			return GetByMobile(mobile, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, TransactionManager tm_)
		{
			return await GetByMobileAsync(mobile, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, int top_)
		{
			return GetByMobile(mobile, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, int top_)
		{
			return await GetByMobileAsync(mobile, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, int top_, TransactionManager tm_)
		{
			return GetByMobile(mobile, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, int top_, TransactionManager tm_)
		{
			return await GetByMobileAsync(mobile, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, string sort_)
		{
			return GetByMobile(mobile, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, string sort_)
		{
			return await GetByMobileAsync(mobile, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, string sort_, TransactionManager tm_)
		{
			return GetByMobile(mobile, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, string sort_, TransactionManager tm_)
		{
			return await GetByMobileAsync(mobile, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Mobile（字段） 查询
		/// </summary>
		/// /// <param name = "mobile">手机号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByMobile(string mobile, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(mobile != null ? "`Mobile` = @Mobile" : "`Mobile` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (mobile != null)
				paras_.Add(Database.CreateInParameter("@Mobile", mobile, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByMobileAsync(string mobile, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(mobile != null ? "`Mobile` = @Mobile" : "`Mobile` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (mobile != null)
				paras_.Add(Database.CreateInParameter("@Mobile", mobile, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByMobile
		#region GetByAmount
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount)
		{
			return GetByAmount(amount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, int top_)
		{
			return GetByAmount(amount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, int top_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, int top_, TransactionManager tm_)
		{
			return GetByAmount(amount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, int top_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, string sort_)
		{
			return GetByAmount(amount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, string sort_)
		{
			return await GetByAmountAsync(amount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, string sort_, TransactionManager tm_)
		{
			return GetByAmount(amount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, string sort_, TransactionManager tm_)
		{
			return await GetByAmountAsync(amount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Amount（字段） 查询
		/// </summary>
		/// /// <param name = "amount">提款金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmount(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountAsync(long amount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Amount` = @Amount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Amount", amount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAmount
		#region GetByCashRate
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate)
		{
			return GetByCashRate(cashRate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate)
		{
			return await GetByCashRateAsync(cashRate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, int top_)
		{
			return GetByCashRate(cashRate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, int top_)
		{
			return await GetByCashRateAsync(cashRate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, int top_, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, int top_, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, string sort_)
		{
			return GetByCashRate(cashRate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, string sort_)
		{
			return await GetByCashRateAsync(cashRate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, string sort_, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, string sort_, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCashRate(float cashRate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashRate` = @CashRate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCashRateAsync(float cashRate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashRate` = @CashRate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByCashRate
		#region GetByBankCode
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode)
		{
			return GetByBankCode(bankCode, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, int top_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, int top_)
		{
			return await GetByBankCodeAsync(bankCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, int top_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, int top_, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, string sort_)
		{
			return GetByBankCode(bankCode, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, string sort_)
		{
			return await GetByBankCodeAsync(bankCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, string sort_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, string sort_, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankCode(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCode != null)
				paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankCodeAsync(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankCode != null ? "`BankCode` = @BankCode" : "`BankCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankCode != null)
				paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByBankCode
		#region GetByBankName
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName)
		{
			return GetByBankName(bankName, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, int top_)
		{
			return GetByBankName(bankName, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, int top_)
		{
			return await GetByBankNameAsync(bankName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, int top_, TransactionManager tm_)
		{
			return GetByBankName(bankName, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, int top_, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, string sort_)
		{
			return GetByBankName(bankName, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, string sort_)
		{
			return await GetByBankNameAsync(bankName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, string sort_, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, string sort_, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankName(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankNameAsync(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByBankName
		#region GetByAccName
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName)
		{
			return GetByAccName(accName, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName)
		{
			return await GetByAccNameAsync(accName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, TransactionManager tm_)
		{
			return GetByAccName(accName, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, int top_)
		{
			return GetByAccName(accName, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, int top_)
		{
			return await GetByAccNameAsync(accName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, int top_, TransactionManager tm_)
		{
			return GetByAccName(accName, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, int top_, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, string sort_)
		{
			return GetByAccName(accName, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, string sort_)
		{
			return await GetByAccNameAsync(accName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, string sort_, TransactionManager tm_)
		{
			return GetByAccName(accName, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, string sort_, TransactionManager tm_)
		{
			return await GetByAccNameAsync(accName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AccName（字段） 查询
		/// </summary>
		/// /// <param name = "accName">用户账户名称</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccName(string accName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accName != null ? "`AccName` = @AccName" : "`AccName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accName != null)
				paras_.Add(Database.CreateInParameter("@AccName", accName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNameAsync(string accName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(accName != null ? "`AccName` = @AccName" : "`AccName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (accName != null)
				paras_.Add(Database.CreateInParameter("@AccName", accName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAccName
		#region GetByAccNumber
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber)
		{
			return GetByAccNumber(accNumber, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber)
		{
			return await GetByAccNumberAsync(accNumber, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, int top_)
		{
			return GetByAccNumber(accNumber, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, int top_)
		{
			return await GetByAccNumberAsync(accNumber, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, int top_, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, int top_, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, string sort_)
		{
			return GetByAccNumber(accNumber, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, string sort_)
		{
			return await GetByAccNumberAsync(accNumber, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, string sort_, TransactionManager tm_)
		{
			return GetByAccNumber(accNumber, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, string sort_, TransactionManager tm_)
		{
			return await GetByAccNumberAsync(accNumber, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AccNumber（字段） 查询
		/// </summary>
		/// /// <param name = "accNumber">用户账号（银行卡号等）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAccNumber(string accNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AccNumber` = @AccNumber", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAccNumberAsync(string accNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AccNumber` = @AccNumber", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AccNumber", accNumber, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAccNumber
		#region GetByChannels
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels)
		{
			return GetByChannels(channels, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels)
		{
			return await GetByChannelsAsync(channels, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, TransactionManager tm_)
		{
			return GetByChannels(channels, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, TransactionManager tm_)
		{
			return await GetByChannelsAsync(channels, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, int top_)
		{
			return GetByChannels(channels, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, int top_)
		{
			return await GetByChannelsAsync(channels, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, int top_, TransactionManager tm_)
		{
			return GetByChannels(channels, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, int top_, TransactionManager tm_)
		{
			return await GetByChannelsAsync(channels, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, string sort_)
		{
			return GetByChannels(channels, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, string sort_)
		{
			return await GetByChannelsAsync(channels, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, string sort_, TransactionManager tm_)
		{
			return GetByChannels(channels, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, string sort_, TransactionManager tm_)
		{
			return await GetByChannelsAsync(channels, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Channels（字段） 查询
		/// </summary>
		/// /// <param name = "channels">提款渠道0-银行卡</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannels(int channels, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Channels` = @Channels", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelsAsync(int channels, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Channels` = @Channels", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channels", channels, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByChannels
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">提款审核状态0-处理中1-通过2-拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByApplyTime
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime)
		{
			return GetByApplyTime(applyTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime)
		{
			return await GetByApplyTimeAsync(applyTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, TransactionManager tm_)
		{
			return GetByApplyTime(applyTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, TransactionManager tm_)
		{
			return await GetByApplyTimeAsync(applyTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, int top_)
		{
			return GetByApplyTime(applyTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, int top_)
		{
			return await GetByApplyTimeAsync(applyTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, int top_, TransactionManager tm_)
		{
			return GetByApplyTime(applyTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, int top_, TransactionManager tm_)
		{
			return await GetByApplyTimeAsync(applyTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, string sort_)
		{
			return GetByApplyTime(applyTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, string sort_)
		{
			return await GetByApplyTimeAsync(applyTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, string sort_, TransactionManager tm_)
		{
			return GetByApplyTime(applyTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, string sort_, TransactionManager tm_)
		{
			return await GetByApplyTimeAsync(applyTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ApplyTime（字段） 查询
		/// </summary>
		/// /// <param name = "applyTime">申请时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByApplyTime(DateTime applyTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ApplyTime` = @ApplyTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByApplyTimeAsync(DateTime applyTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ApplyTime` = @ApplyTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ApplyTime", applyTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByApplyTime
		#region GetByAuditTime
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime)
		{
			return GetByAuditTime(auditTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime)
		{
			return await GetByAuditTimeAsync(auditTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, TransactionManager tm_)
		{
			return GetByAuditTime(auditTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, TransactionManager tm_)
		{
			return await GetByAuditTimeAsync(auditTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, int top_)
		{
			return GetByAuditTime(auditTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, int top_)
		{
			return await GetByAuditTimeAsync(auditTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, int top_, TransactionManager tm_)
		{
			return GetByAuditTime(auditTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, int top_, TransactionManager tm_)
		{
			return await GetByAuditTimeAsync(auditTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, string sort_)
		{
			return GetByAuditTime(auditTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, string sort_)
		{
			return await GetByAuditTimeAsync(auditTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, string sort_, TransactionManager tm_)
		{
			return GetByAuditTime(auditTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, string sort_, TransactionManager tm_)
		{
			return await GetByAuditTimeAsync(auditTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AuditTime（字段） 查询
		/// </summary>
		/// /// <param name = "auditTime">审批时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAuditTime(DateTime? auditTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(auditTime.HasValue ? "`AuditTime` = @AuditTime" : "`AuditTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (auditTime.HasValue)
				paras_.Add(Database.CreateInParameter("@AuditTime", auditTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAuditTimeAsync(DateTime? auditTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(auditTime.HasValue ? "`AuditTime` = @AuditTime" : "`AuditTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (auditTime.HasValue)
				paras_.Add(Database.CreateInParameter("@AuditTime", auditTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAuditTime
		#region GetByOperatorUser
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser)
		{
			return GetByOperatorUser(operatorUser, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser)
		{
			return await GetByOperatorUserAsync(operatorUser, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, TransactionManager tm_)
		{
			return GetByOperatorUser(operatorUser, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, TransactionManager tm_)
		{
			return await GetByOperatorUserAsync(operatorUser, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, int top_)
		{
			return GetByOperatorUser(operatorUser, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, int top_)
		{
			return await GetByOperatorUserAsync(operatorUser, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, int top_, TransactionManager tm_)
		{
			return GetByOperatorUser(operatorUser, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, int top_, TransactionManager tm_)
		{
			return await GetByOperatorUserAsync(operatorUser, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, string sort_)
		{
			return GetByOperatorUser(operatorUser, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, string sort_)
		{
			return await GetByOperatorUserAsync(operatorUser, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, string sort_, TransactionManager tm_)
		{
			return GetByOperatorUser(operatorUser, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, string sort_, TransactionManager tm_)
		{
			return await GetByOperatorUserAsync(operatorUser, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OperatorUser（字段） 查询
		/// </summary>
		/// /// <param name = "operatorUser">审批人</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByOperatorUser(string operatorUser, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorUser != null ? "`OperatorUser` = @OperatorUser" : "`OperatorUser` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorUser != null)
				paras_.Add(Database.CreateInParameter("@OperatorUser", operatorUser, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByOperatorUserAsync(string operatorUser, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorUser != null ? "`OperatorUser` = @OperatorUser" : "`OperatorUser` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorUser != null)
				paras_.Add(Database.CreateInParameter("@OperatorUser", operatorUser, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByOperatorUser
		#region GetByBankID
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID)
		{
			return GetByBankID(bankID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, int top_)
		{
			return GetByBankID(bankID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, int top_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, int top_, TransactionManager tm_)
		{
			return GetByBankID(bankID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, int top_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, string sort_)
		{
			return GetByBankID(bankID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, string sort_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, string sort_, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, string sort_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">BankId</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankID(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankID != null ? "`BankID` = @BankID" : "`BankID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankID != null)
				paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankIDAsync(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankID != null ? "`BankID` = @BankID" : "`BankID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankID != null)
				paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByBankID
		#region GetByPaytype
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype)
		{
			return GetByPaytype(paytype, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype)
		{
			return await GetByPaytypeAsync(paytype, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, TransactionManager tm_)
		{
			return GetByPaytype(paytype, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, TransactionManager tm_)
		{
			return await GetByPaytypeAsync(paytype, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, int top_)
		{
			return GetByPaytype(paytype, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, int top_)
		{
			return await GetByPaytypeAsync(paytype, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, int top_, TransactionManager tm_)
		{
			return GetByPaytype(paytype, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, int top_, TransactionManager tm_)
		{
			return await GetByPaytypeAsync(paytype, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, string sort_)
		{
			return GetByPaytype(paytype, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, string sort_)
		{
			return await GetByPaytypeAsync(paytype, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, string sort_, TransactionManager tm_)
		{
			return GetByPaytype(paytype, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, string sort_, TransactionManager tm_)
		{
			return await GetByPaytypeAsync(paytype, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Paytype（字段） 查询
		/// </summary>
		/// /// <param name = "paytype">paytype(1.visa,2.spei3.mongopay4.pandapay)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByPaytype(int paytype, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Paytype` = @Paytype", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByPaytypeAsync(int paytype, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Paytype` = @Paytype", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Paytype", paytype, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByPaytype
		#region GetByChannel
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel)
		{
			return GetByChannel(channel, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel)
		{
			return await GetByChannelAsync(channel, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, TransactionManager tm_)
		{
			return GetByChannel(channel, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, TransactionManager tm_)
		{
			return await GetByChannelAsync(channel, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, int top_)
		{
			return GetByChannel(channel, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, int top_)
		{
			return await GetByChannelAsync(channel, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, int top_, TransactionManager tm_)
		{
			return GetByChannel(channel, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, int top_, TransactionManager tm_)
		{
			return await GetByChannelAsync(channel, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, string sort_)
		{
			return GetByChannel(channel, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, string sort_)
		{
			return await GetByChannelAsync(channel, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, string sort_, TransactionManager tm_)
		{
			return GetByChannel(channel, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, string sort_, TransactionManager tm_)
		{
			return await GetByChannelAsync(channel, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Channel（字段） 查询
		/// </summary>
		/// /// <param name = "channel">bankid对应支持的渠道编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByChannel(int channel, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Channel` = @Channel", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByChannelAsync(int channel, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Channel` = @Channel", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Channel", channel, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByChannel
		#region GetByRequestParam
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam)
		{
			return GetByRequestParam(requestParam, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam)
		{
			return await GetByRequestParamAsync(requestParam, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, TransactionManager tm_)
		{
			return GetByRequestParam(requestParam, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, TransactionManager tm_)
		{
			return await GetByRequestParamAsync(requestParam, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, int top_)
		{
			return GetByRequestParam(requestParam, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, int top_)
		{
			return await GetByRequestParamAsync(requestParam, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, int top_, TransactionManager tm_)
		{
			return GetByRequestParam(requestParam, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, int top_, TransactionManager tm_)
		{
			return await GetByRequestParamAsync(requestParam, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, string sort_)
		{
			return GetByRequestParam(requestParam, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, string sort_)
		{
			return await GetByRequestParamAsync(requestParam, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, string sort_, TransactionManager tm_)
		{
			return GetByRequestParam(requestParam, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, string sort_, TransactionManager tm_)
		{
			return await GetByRequestParamAsync(requestParam, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RequestParam（字段） 查询
		/// </summary>
		/// /// <param name = "requestParam">请求参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestParam(string requestParam, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestParam != null ? "`RequestParam` = @RequestParam" : "`RequestParam` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestParam != null)
				paras_.Add(Database.CreateInParameter("@RequestParam", requestParam, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestParamAsync(string requestParam, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestParam != null ? "`RequestParam` = @RequestParam" : "`RequestParam` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestParam != null)
				paras_.Add(Database.CreateInParameter("@RequestParam", requestParam, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByRequestParam
		#region GetByRemark
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark)
		{
			return GetByRemark(remark, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark)
		{
			return await GetByRemarkAsync(remark, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, TransactionManager tm_)
		{
			return GetByRemark(remark, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, TransactionManager tm_)
		{
			return await GetByRemarkAsync(remark, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, int top_)
		{
			return GetByRemark(remark, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, int top_)
		{
			return await GetByRemarkAsync(remark, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, int top_, TransactionManager tm_)
		{
			return GetByRemark(remark, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, int top_, TransactionManager tm_)
		{
			return await GetByRemarkAsync(remark, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, string sort_)
		{
			return GetByRemark(remark, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, string sort_)
		{
			return await GetByRemarkAsync(remark, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, string sort_, TransactionManager tm_)
		{
			return GetByRemark(remark, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, string sort_, TransactionManager tm_)
		{
			return await GetByRemarkAsync(remark, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Remark（字段） 查询
		/// </summary>
		/// /// <param name = "remark">备注</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRemark(string remark, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(remark != null ? "`Remark` = @Remark" : "`Remark` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (remark != null)
				paras_.Add(Database.CreateInParameter("@Remark", remark, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRemarkAsync(string remark, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(remark != null ? "`Remark` = @Remark" : "`Remark` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (remark != null)
				paras_.Add(Database.CreateInParameter("@Remark", remark, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByRemark
		#region GetByIsAudit
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit)
		{
			return GetByIsAudit(isAudit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit)
		{
			return await GetByIsAuditAsync(isAudit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, int top_)
		{
			return GetByIsAudit(isAudit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, int top_)
		{
			return await GetByIsAuditAsync(isAudit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, int top_, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, int top_, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, string sort_)
		{
			return GetByIsAudit(isAudit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, string sort_)
		{
			return await GetByIsAuditAsync(isAudit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, string sort_, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, string sort_, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">是否需要审核</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByIsAudit(bool isAudit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAudit` = @IsAudit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByIsAuditAsync(bool isAudit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAudit` = @IsAudit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByIsAudit
		#region GetByAmountBalance
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance)
		{
			return GetByAmountBalance(amountBalance, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance)
		{
			return await GetByAmountBalanceAsync(amountBalance, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, TransactionManager tm_)
		{
			return GetByAmountBalance(amountBalance, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, TransactionManager tm_)
		{
			return await GetByAmountBalanceAsync(amountBalance, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, int top_)
		{
			return GetByAmountBalance(amountBalance, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, int top_)
		{
			return await GetByAmountBalanceAsync(amountBalance, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, int top_, TransactionManager tm_)
		{
			return GetByAmountBalance(amountBalance, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, int top_, TransactionManager tm_)
		{
			return await GetByAmountBalanceAsync(amountBalance, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, string sort_)
		{
			return GetByAmountBalance(amountBalance, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, string sort_)
		{
			return await GetByAmountBalanceAsync(amountBalance, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, string sort_, TransactionManager tm_)
		{
			return GetByAmountBalance(amountBalance, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, string sort_, TransactionManager tm_)
		{
			return await GetByAmountBalanceAsync(amountBalance, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AmountBalance（字段） 查询
		/// </summary>
		/// /// <param name = "amountBalance">balance变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBalance(long amountBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBalance` = @AmountBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBalanceAsync(long amountBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBalance` = @AmountBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBalance", amountBalance, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAmountBalance
		#region GetByAmountBonus
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus)
		{
			return GetByAmountBonus(amountBonus, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, int top_)
		{
			return GetByAmountBonus(amountBonus, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, int top_)
		{
			return await GetByAmountBonusAsync(amountBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, int top_, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, int top_, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, string sort_)
		{
			return GetByAmountBonus(amountBonus, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, string sort_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, string sort_, TransactionManager tm_)
		{
			return GetByAmountBonus(amountBonus, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, string sort_, TransactionManager tm_)
		{
			return await GetByAmountBonusAsync(amountBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AmountBonus（字段） 查询
		/// </summary>
		/// /// <param name = "amountBonus">bonus变化额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByAmountBonus(long amountBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBonus` = @AmountBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByAmountBonusAsync(long amountBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AmountBonus` = @AmountBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AmountBonus", amountBonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByAmountBonus
		#region GetByBankOrderId
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId)
		{
			return GetByBankOrderId(bankOrderId, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, int top_)
		{
			return GetByBankOrderId(bankOrderId, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, int top_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, int top_, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, int top_, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, string sort_)
		{
			return GetByBankOrderId(bankOrderId, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, string sort_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, string sort_, TransactionManager tm_)
		{
			return GetByBankOrderId(bankOrderId, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, string sort_, TransactionManager tm_)
		{
			return await GetByBankOrderIdAsync(bankOrderId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "bankOrderId">sb_bank_order表中Orderid</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByBankOrderId(string bankOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankOrderId != null ? "`BankOrderId` = @BankOrderId" : "`BankOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankOrderId != null)
				paras_.Add(Database.CreateInParameter("@BankOrderId", bankOrderId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByBankOrderIdAsync(string bankOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankOrderId != null ? "`BankOrderId` = @BankOrderId" : "`BankOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankOrderId != null)
				paras_.Add(Database.CreateInParameter("@BankOrderId", bankOrderId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByBankOrderId
		#region GetByRequestTime
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime)
		{
			return GetByRequestTime(requestTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime)
		{
			return await GetByRequestTimeAsync(requestTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, int top_)
		{
			return GetByRequestTime(requestTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, int top_)
		{
			return await GetByRequestTimeAsync(requestTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, int top_, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, int top_, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, string sort_)
		{
			return GetByRequestTime(requestTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, string sort_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, string sort_, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, string sort_, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByRequestTime(DateTime? requestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestTime.HasValue ? "`RequestTime` = @RequestTime" : "`RequestTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestTime.HasValue)
				paras_.Add(Database.CreateInParameter("@RequestTime", requestTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByRequestTimeAsync(DateTime? requestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestTime.HasValue ? "`RequestTime` = @RequestTime" : "`RequestTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestTime.HasValue)
				paras_.Add(Database.CreateInParameter("@RequestTime", requestTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByRequestTime
		#region GetByResponseTime
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime)
		{
			return GetByResponseTime(responseTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime)
		{
			return await GetByResponseTimeAsync(responseTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, TransactionManager tm_)
		{
			return await GetByResponseTimeAsync(responseTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, int top_)
		{
			return GetByResponseTime(responseTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_)
		{
			return await GetByResponseTimeAsync(responseTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, int top_, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_, TransactionManager tm_)
		{
			return await GetByResponseTimeAsync(responseTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, string sort_)
		{
			return GetByResponseTime(responseTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, string sort_)
		{
			return await GetByResponseTimeAsync(responseTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, string sort_, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, string sort_, TransactionManager tm_)
		{
			return await GetByResponseTimeAsync(responseTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByResponseTime(DateTime? responseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseTime.HasValue ? "`ResponseTime` = @ResponseTime" : "`ResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@ResponseTime", responseTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseTime.HasValue ? "`ResponseTime` = @ResponseTime" : "`ResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@ResponseTime", responseTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByResponseTime
		#region GetByCallbackTime
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime)
		{
			return GetByCallbackTime(callbackTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime)
		{
			return await GetByCallbackTimeAsync(callbackTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, TransactionManager tm_)
		{
			return GetByCallbackTime(callbackTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, TransactionManager tm_)
		{
			return await GetByCallbackTimeAsync(callbackTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, int top_)
		{
			return GetByCallbackTime(callbackTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, int top_)
		{
			return await GetByCallbackTimeAsync(callbackTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, int top_, TransactionManager tm_)
		{
			return GetByCallbackTime(callbackTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, int top_, TransactionManager tm_)
		{
			return await GetByCallbackTimeAsync(callbackTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, string sort_)
		{
			return GetByCallbackTime(callbackTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, string sort_)
		{
			return await GetByCallbackTimeAsync(callbackTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, string sort_, TransactionManager tm_)
		{
			return GetByCallbackTime(callbackTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, string sort_, TransactionManager tm_)
		{
			return await GetByCallbackTimeAsync(callbackTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CallbackTime（字段） 查询
		/// </summary>
		/// /// <param name = "callbackTime">回调时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByCallbackTime(DateTime? callbackTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(callbackTime.HasValue ? "`CallbackTime` = @CallbackTime" : "`CallbackTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (callbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@CallbackTime", callbackTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByCallbackTimeAsync(DateTime? callbackTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(callbackTime.HasValue ? "`CallbackTime` = @CallbackTime" : "`CallbackTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (callbackTime.HasValue)
				paras_.Add(Database.CreateInParameter("@CallbackTime", callbackTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByCallbackTime
		#region GetByReason
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason)
		{
			return GetByReason(reason, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason)
		{
			return await GetByReasonAsync(reason, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, TransactionManager tm_)
		{
			return GetByReason(reason, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, TransactionManager tm_)
		{
			return await GetByReasonAsync(reason, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, int top_)
		{
			return GetByReason(reason, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, int top_)
		{
			return await GetByReasonAsync(reason, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, int top_, TransactionManager tm_)
		{
			return GetByReason(reason, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, int top_, TransactionManager tm_)
		{
			return await GetByReasonAsync(reason, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, string sort_)
		{
			return GetByReason(reason, 0, sort_, null);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, string sort_)
		{
			return await GetByReasonAsync(reason, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, string sort_, TransactionManager tm_)
		{
			return GetByReason(reason, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, string sort_, TransactionManager tm_)
		{
			return await GetByReasonAsync(reason, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Reason（字段） 查询
		/// </summary>
		/// /// <param name = "reason">原因</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_auditEO> GetByReason(string reason, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(reason != null ? "`Reason` = @Reason" : "`Reason` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (reason != null)
				paras_.Add(Database.CreateInParameter("@Reason", reason, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		public async Task<List<Sc_cash_auditEO>> GetByReasonAsync(string reason, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(reason != null ? "`Reason` = @Reason" : "`Reason` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (reason != null)
				paras_.Add(Database.CreateInParameter("@Reason", reason, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_auditEO.MapDataReader);
		}
		#endregion // GetByReason
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
