/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-03-27 20: 08:04
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

namespace Lobby.Flow.DAL
{
	#region EO
	/// <summary>
	/// 
	/// 【表 sc_cash_audit_log 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_audit_logEO : IRowMapper<Sc_cash_audit_logEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_audit_logEO()
		{
			this.Action = 0;
			this.RecDate = DateTime.Now;
			this.TransType = 0;
			this.RequestTime = DateTime.Now;
			this.Status = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalAuditLogID;
		/// <summary>
		/// 【数据库中的原始主键 AuditLogID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalAuditLogID
		{
			get { return _originalAuditLogID; }
			set { HasOriginal = true; _originalAuditLogID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "AuditLogID", AuditLogID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// GUID
		/// 【主键 varchar(36)】
		/// </summary>
		[DataMember(Order = 1)]
		public string AuditLogID { get; set; }
		/// <summary>
		/// 主键guid
		/// 【字段 varchar(36)】
		/// </summary>
		[DataMember(Order = 2)]
		public string CashAuditID { get; set; }
		/// <summary>
		/// 操作0-提交申请1-审批通过2-审批拒绝
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 3)]
		public int Action { get; set; }
		/// <summary>
		/// 操作人ID
		/// 【字段 varchar(36)】
		/// </summary>
		[DataMember(Order = 4)]
		public string OperatorId { get; set; }
		/// <summary>
		/// 操作人
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 5)]
		public string OperatorName { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 6)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// 通讯类型(0-我方发起1-对方发起)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 7)]
		public int TransType { get; set; }
		/// <summary>
		/// 通讯标记（接口标识）
		/// 【字段 varchar(255)】
		/// </summary>
		[DataMember(Order = 8)]
		public string TransMark { get; set; }
		/// <summary>
		/// 请求消息（我方请求或对方push）json
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 9)]
		public string RequestBody { get; set; }
		/// <summary>
		/// 请求时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 10)]
		public DateTime RequestTime { get; set; }
		/// <summary>
		/// 返回时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 11)]
		public DateTime? ResponseTime { get; set; }
		/// <summary>
		/// 响应消息（对方响应或我方响应）json
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 12)]
		public string ResponseBody { get; set; }
		/// <summary>
		/// 异常消息
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 13)]
		public string Exception { get; set; }
		/// <summary>
		/// 消息状态
		///              0-初始
		///              1-调用成功
		///              2-返回错误或调用异常，无需处理
		///              3-出现异常，需处理
		///              4-异常已处理
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 14)]
		public int Status { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_audit_logEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_audit_logEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_audit_logEO ret = new Sc_cash_audit_logEO();
			ret.AuditLogID = reader.ToString("AuditLogID");
			ret.OriginalAuditLogID = ret.AuditLogID;
			ret.CashAuditID = reader.ToString("CashAuditID");
			ret.Action = reader.ToInt32("Action");
			ret.OperatorId = reader.ToString("OperatorId");
			ret.OperatorName = reader.ToString("OperatorName");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.TransType = reader.ToInt32("TransType");
			ret.TransMark = reader.ToString("TransMark");
			ret.RequestBody = reader.ToString("RequestBody");
			ret.RequestTime = reader.ToDateTime("RequestTime");
			ret.ResponseTime = reader.ToDateTimeN("ResponseTime");
			ret.ResponseBody = reader.ToString("ResponseBody");
			ret.Exception = reader.ToString("Exception");
			ret.Status = reader.ToInt32("Status");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 
	/// 【表 sc_cash_audit_log 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_audit_logMO : MySqlTableMO<Sc_cash_audit_logEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_audit_log`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_audit_logMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_audit_logMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_audit_logMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_audit_logEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_cash_audit_logEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_cash_audit_logEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`AuditLogID`, `CashAuditID`, `Action`, `OperatorId`, `OperatorName`, `RecDate`, `TransType`, `TransMark`, `RequestBody`, `RequestTime`, `ResponseTime`, `ResponseBody`, `Exception`, `Status`) VALUE (@AuditLogID, @CashAuditID, @Action, @OperatorId, @OperatorName, @RecDate, @TransType, @TransMark, @RequestBody, @RequestTime, @ResponseTime, @ResponseBody, @Exception, @Status);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", item.AuditLogID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", item.CashAuditID != null ? item.CashAuditID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Action", item.Action, MySqlDbType.Int32),
				Database.CreateInParameter("@OperatorId", item.OperatorId, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorName", item.OperatorName, MySqlDbType.VarChar),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@TransType", item.TransType, MySqlDbType.Int32),
				Database.CreateInParameter("@TransMark", item.TransMark != null ? item.TransMark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RequestBody", item.RequestBody != null ? item.RequestBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@RequestTime", item.RequestTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@ResponseTime", item.ResponseTime.HasValue ? item.ResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@ResponseBody", item.ResponseBody != null ? item.ResponseBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Exception", item.Exception != null ? item.Exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_audit_logEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_audit_logEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_audit_logEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`AuditLogID`, `CashAuditID`, `Action`, `OperatorId`, `OperatorName`, `RecDate`, `TransType`, `TransMark`, `RequestBody`, `RequestTime`, `ResponseTime`, `ResponseBody`, `Exception`, `Status`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.AuditLogID}','{item.CashAuditID}',{item.Action},'{item.OperatorId}','{item.OperatorName}','{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.TransType},'{item.TransMark}','{item.RequestBody}','{item.RequestTime.ToString("yyyy-MM-dd HH:mm:ss")}','{item.ResponseTime?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.ResponseBody}','{item.Exception}',{item.Status}),");
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
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string auditLogID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(auditLogID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(auditLogID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string auditLogID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_audit_logEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.AuditLogID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_audit_logEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.AuditLogID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByCashAuditID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashAuditID(string cashAuditID, TransactionManager tm_ = null)
		{
			RepairRemoveByCashAuditIDData(cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashAuditIDAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			RepairRemoveByCashAuditIDData(cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashAuditIDData(string cashAuditID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (cashAuditID != null ? "`CashAuditID` = @CashAuditID" : "`CashAuditID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (cashAuditID != null)
				paras_.Add(Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCashAuditID
		#region RemoveByAction
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAction(int action, TransactionManager tm_ = null)
		{
			RepairRemoveByActionData(action, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByActionAsync(int action, TransactionManager tm_ = null)
		{
			RepairRemoveByActionData(action, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByActionData(int action, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `Action` = @Action";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Action", action, MySqlDbType.Int32));
		}
		#endregion // RemoveByAction
		#region RemoveByOperatorId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperatorId(string operatorId, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIdData(operatorId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOperatorIdAsync(string operatorId, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIdData(operatorId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOperatorIdData(string operatorId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorId` = @OperatorId";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOperatorId
		#region RemoveByOperatorName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperatorName(string operatorName, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorNameData(operatorName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOperatorNameAsync(string operatorName, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorNameData(operatorName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOperatorNameData(string operatorName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorName` = @OperatorName";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOperatorName
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
		#region RemoveByTransType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTransType(int transType, TransactionManager tm_ = null)
		{
			RepairRemoveByTransTypeData(transType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTransTypeAsync(int transType, TransactionManager tm_ = null)
		{
			RepairRemoveByTransTypeData(transType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTransTypeData(int transType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TransType` = @TransType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32));
		}
		#endregion // RemoveByTransType
		#region RemoveByTransMark
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTransMark(string transMark, TransactionManager tm_ = null)
		{
			RepairRemoveByTransMarkData(transMark, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTransMarkAsync(string transMark, TransactionManager tm_ = null)
		{
			RepairRemoveByTransMarkData(transMark, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTransMarkData(string transMark, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (transMark != null ? "`TransMark` = @TransMark" : "`TransMark` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (transMark != null)
				paras_.Add(Database.CreateInParameter("@TransMark", transMark, MySqlDbType.VarChar));
		}
		#endregion // RemoveByTransMark
		#region RemoveByRequestBody
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRequestBody(string requestBody, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestBodyData(requestBody, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRequestBodyAsync(string requestBody, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestBodyData(requestBody, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRequestBodyData(string requestBody, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (requestBody != null ? "`RequestBody` = @RequestBody" : "`RequestBody` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (requestBody != null)
				paras_.Add(Database.CreateInParameter("@RequestBody", requestBody, MySqlDbType.Text));
		}
		#endregion // RemoveByRequestBody
		#region RemoveByRequestTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRequestTime(DateTime requestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestTimeData(requestTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRequestTimeAsync(DateTime requestTime, TransactionManager tm_ = null)
		{
			RepairRemoveByRequestTimeData(requestTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRequestTimeData(DateTime requestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RequestTime` = @RequestTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime));
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
		#region RemoveByResponseBody
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByResponseBody(string responseBody, TransactionManager tm_ = null)
		{
			RepairRemoveByResponseBodyData(responseBody, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByResponseBodyAsync(string responseBody, TransactionManager tm_ = null)
		{
			RepairRemoveByResponseBodyData(responseBody, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByResponseBodyData(string responseBody, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (responseBody != null ? "`ResponseBody` = @ResponseBody" : "`ResponseBody` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (responseBody != null)
				paras_.Add(Database.CreateInParameter("@ResponseBody", responseBody, MySqlDbType.Text));
		}
		#endregion // RemoveByResponseBody
		#region RemoveByException
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByException(string exception, TransactionManager tm_ = null)
		{
			RepairRemoveByExceptionData(exception, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByExceptionAsync(string exception, TransactionManager tm_ = null)
		{
			RepairRemoveByExceptionData(exception, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByExceptionData(string exception, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (exception != null ? "`Exception` = @Exception" : "`Exception` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (exception != null)
				paras_.Add(Database.CreateInParameter("@Exception", exception, MySqlDbType.Text));
		}
		#endregion // RemoveByException
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">消息状态</param>
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
		public int Put(Sc_cash_audit_logEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_audit_logEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_audit_logEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AuditLogID` = @AuditLogID, `CashAuditID` = @CashAuditID, `Action` = @Action, `OperatorId` = @OperatorId, `OperatorName` = @OperatorName, `TransType` = @TransType, `TransMark` = @TransMark, `RequestBody` = @RequestBody, `ResponseTime` = @ResponseTime, `ResponseBody` = @ResponseBody, `Exception` = @Exception, `Status` = @Status WHERE `AuditLogID` = @AuditLogID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", item.AuditLogID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CashAuditID", item.CashAuditID != null ? item.CashAuditID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Action", item.Action, MySqlDbType.Int32),
				Database.CreateInParameter("@OperatorId", item.OperatorId, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorName", item.OperatorName, MySqlDbType.VarChar),
				Database.CreateInParameter("@TransType", item.TransType, MySqlDbType.Int32),
				Database.CreateInParameter("@TransMark", item.TransMark != null ? item.TransMark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RequestBody", item.RequestBody != null ? item.RequestBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@ResponseTime", item.ResponseTime.HasValue ? item.ResponseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@ResponseBody", item.ResponseBody != null ? item.ResponseBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Exception", item.Exception != null ? item.Exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@AuditLogID_Original", item.HasOriginal ? item.OriginalAuditLogID : item.AuditLogID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_audit_logEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_audit_logEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string auditLogID, string set_, params object[] values_)
		{
			return Put(set_, "`AuditLogID` = @AuditLogID", ConcatValues(values_, auditLogID));
		}
		public async Task<int> PutByPKAsync(string auditLogID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`AuditLogID` = @AuditLogID", ConcatValues(values_, auditLogID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string auditLogID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`AuditLogID` = @AuditLogID", tm_, ConcatValues(values_, auditLogID));
		}
		public async Task<int> PutByPKAsync(string auditLogID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`AuditLogID` = @AuditLogID", tm_, ConcatValues(values_, auditLogID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string auditLogID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`AuditLogID` = @AuditLogID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string auditLogID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`AuditLogID` = @AuditLogID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutCashAuditID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashAuditIDByPK(string auditLogID, string cashAuditID, TransactionManager tm_ = null)
		{
			RepairPutCashAuditIDByPKData(auditLogID, cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashAuditIDByPKAsync(string auditLogID, string cashAuditID, TransactionManager tm_ = null)
		{
			RepairPutCashAuditIDByPKData(auditLogID, cashAuditID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashAuditIDByPKData(string auditLogID, string cashAuditID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashAuditID` = @CashAuditID  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAuditID", cashAuditID != null ? cashAuditID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashAuditID(string cashAuditID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashAuditID` = @CashAuditID";
			var parameter_ = Database.CreateInParameter("@CashAuditID", cashAuditID != null ? cashAuditID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashAuditIDAsync(string cashAuditID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashAuditID` = @CashAuditID";
			var parameter_ = Database.CreateInParameter("@CashAuditID", cashAuditID != null ? cashAuditID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashAuditID
		#region PutAction
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutActionByPK(string auditLogID, int action, TransactionManager tm_ = null)
		{
			RepairPutActionByPKData(auditLogID, action, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutActionByPKAsync(string auditLogID, int action, TransactionManager tm_ = null)
		{
			RepairPutActionByPKData(auditLogID, action, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutActionByPKData(string auditLogID, int action, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Action` = @Action  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Action", action, MySqlDbType.Int32),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAction(int action, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Action` = @Action";
			var parameter_ = Database.CreateInParameter("@Action", action, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutActionAsync(int action, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Action` = @Action";
			var parameter_ = Database.CreateInParameter("@Action", action, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAction
		#region PutOperatorId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIdByPK(string auditLogID, string operatorId, TransactionManager tm_ = null)
		{
			RepairPutOperatorIdByPKData(auditLogID, operatorId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIdByPKAsync(string auditLogID, string operatorId, TransactionManager tm_ = null)
		{
			RepairPutOperatorIdByPKData(auditLogID, operatorId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIdByPKData(string auditLogID, string operatorId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorId` = @OperatorId  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorId(string operatorId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorId` = @OperatorId";
			var parameter_ = Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorIdAsync(string operatorId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorId` = @OperatorId";
			var parameter_ = Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorId
		#region PutOperatorName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorNameByPK(string auditLogID, string operatorName, TransactionManager tm_ = null)
		{
			RepairPutOperatorNameByPKData(auditLogID, operatorName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorNameByPKAsync(string auditLogID, string operatorName, TransactionManager tm_ = null)
		{
			RepairPutOperatorNameByPKData(auditLogID, operatorName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorNameByPKData(string auditLogID, string operatorName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorName` = @OperatorName  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorName(string operatorName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorName` = @OperatorName";
			var parameter_ = Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorNameAsync(string operatorName, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorName` = @OperatorName";
			var parameter_ = Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorName
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string auditLogID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(auditLogID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string auditLogID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(auditLogID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string auditLogID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
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
		#region PutTransType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransTypeByPK(string auditLogID, int transType, TransactionManager tm_ = null)
		{
			RepairPutTransTypeByPKData(auditLogID, transType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTransTypeByPKAsync(string auditLogID, int transType, TransactionManager tm_ = null)
		{
			RepairPutTransTypeByPKData(auditLogID, transType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTransTypeByPKData(string auditLogID, int transType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TransType` = @TransType  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransType(int transType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransType` = @TransType";
			var parameter_ = Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTransTypeAsync(int transType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransType` = @TransType";
			var parameter_ = Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTransType
		#region PutTransMark
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransMarkByPK(string auditLogID, string transMark, TransactionManager tm_ = null)
		{
			RepairPutTransMarkByPKData(auditLogID, transMark, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTransMarkByPKAsync(string auditLogID, string transMark, TransactionManager tm_ = null)
		{
			RepairPutTransMarkByPKData(auditLogID, transMark, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTransMarkByPKData(string auditLogID, string transMark, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TransMark` = @TransMark  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TransMark", transMark != null ? transMark : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTransMark(string transMark, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransMark` = @TransMark";
			var parameter_ = Database.CreateInParameter("@TransMark", transMark != null ? transMark : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTransMarkAsync(string transMark, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TransMark` = @TransMark";
			var parameter_ = Database.CreateInParameter("@TransMark", transMark != null ? transMark : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTransMark
		#region PutRequestBody
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestBodyByPK(string auditLogID, string requestBody, TransactionManager tm_ = null)
		{
			RepairPutRequestBodyByPKData(auditLogID, requestBody, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRequestBodyByPKAsync(string auditLogID, string requestBody, TransactionManager tm_ = null)
		{
			RepairPutRequestBodyByPKData(auditLogID, requestBody, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRequestBodyByPKData(string auditLogID, string requestBody, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RequestBody` = @RequestBody  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RequestBody", requestBody != null ? requestBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestBody(string requestBody, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestBody` = @RequestBody";
			var parameter_ = Database.CreateInParameter("@RequestBody", requestBody != null ? requestBody : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRequestBodyAsync(string requestBody, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestBody` = @RequestBody";
			var parameter_ = Database.CreateInParameter("@RequestBody", requestBody != null ? requestBody : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRequestBody
		#region PutRequestTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestTimeByPK(string auditLogID, DateTime requestTime, TransactionManager tm_ = null)
		{
			RepairPutRequestTimeByPKData(auditLogID, requestTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRequestTimeByPKAsync(string auditLogID, DateTime requestTime, TransactionManager tm_ = null)
		{
			RepairPutRequestTimeByPKData(auditLogID, requestTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRequestTimeByPKData(string auditLogID, DateTime requestTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequestTime(DateTime requestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime";
			var parameter_ = Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRequestTimeAsync(DateTime requestTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequestTime` = @RequestTime";
			var parameter_ = Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRequestTime
		#region PutResponseTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutResponseTimeByPK(string auditLogID, DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairPutResponseTimeByPKData(auditLogID, responseTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutResponseTimeByPKAsync(string auditLogID, DateTime? responseTime, TransactionManager tm_ = null)
		{
			RepairPutResponseTimeByPKData(auditLogID, responseTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutResponseTimeByPKData(string auditLogID, DateTime? responseTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ResponseTime` = @ResponseTime  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ResponseTime", responseTime.HasValue ? responseTime.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
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
		#region PutResponseBody
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutResponseBodyByPK(string auditLogID, string responseBody, TransactionManager tm_ = null)
		{
			RepairPutResponseBodyByPKData(auditLogID, responseBody, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutResponseBodyByPKAsync(string auditLogID, string responseBody, TransactionManager tm_ = null)
		{
			RepairPutResponseBodyByPKData(auditLogID, responseBody, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutResponseBodyByPKData(string auditLogID, string responseBody, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ResponseBody` = @ResponseBody  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ResponseBody", responseBody != null ? responseBody : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutResponseBody(string responseBody, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ResponseBody` = @ResponseBody";
			var parameter_ = Database.CreateInParameter("@ResponseBody", responseBody != null ? responseBody : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutResponseBodyAsync(string responseBody, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ResponseBody` = @ResponseBody";
			var parameter_ = Database.CreateInParameter("@ResponseBody", responseBody != null ? responseBody : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutResponseBody
		#region PutException
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "exception">异常消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutExceptionByPK(string auditLogID, string exception, TransactionManager tm_ = null)
		{
			RepairPutExceptionByPKData(auditLogID, exception, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutExceptionByPKAsync(string auditLogID, string exception, TransactionManager tm_ = null)
		{
			RepairPutExceptionByPKData(auditLogID, exception, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutExceptionByPKData(string auditLogID, string exception, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Exception` = @Exception  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Exception", exception != null ? exception : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutException(string exception, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Exception` = @Exception";
			var parameter_ = Database.CreateInParameter("@Exception", exception != null ? exception : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutExceptionAsync(string exception, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Exception` = @Exception";
			var parameter_ = Database.CreateInParameter("@Exception", exception != null ? exception : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutException
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// /// <param name = "status">消息状态</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string auditLogID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(auditLogID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string auditLogID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(auditLogID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string auditLogID, int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `AuditLogID` = @AuditLogID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">消息状态</param>
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_cash_audit_logEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.AuditLogID) == null)
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
		public async Task<bool> SetAsync(Sc_cash_audit_logEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.AuditLogID) == null)
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
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_audit_logEO GetByPK(string auditLogID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(auditLogID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<Sc_cash_audit_logEO> GetByPKAsync(string auditLogID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(auditLogID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		private void RepairGetByPKData(string auditLogID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`AuditLogID` = @AuditLogID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 CashAuditID（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCashAuditIDByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CashAuditID`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetCashAuditIDByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CashAuditID`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Action（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetActionByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Action`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<int> GetActionByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Action`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorId（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIdByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorId`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetOperatorIdByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorId`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorName（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorNameByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorName`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetOperatorNameByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorName`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TransType（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetTransTypeByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`TransType`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<int> GetTransTypeByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`TransType`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TransMark（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetTransMarkByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`TransMark`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetTransMarkByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`TransMark`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RequestBody（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetRequestBodyByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`RequestBody`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetRequestBodyByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`RequestBody`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RequestTime（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRequestTimeByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RequestTime`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<DateTime> GetRequestTimeByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RequestTime`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ResponseTime（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetResponseTimeByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`ResponseTime`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<DateTime?> GetResponseTimeByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`ResponseTime`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ResponseBody（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetResponseBodyByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`ResponseBody`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetResponseBodyByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`ResponseBody`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Exception（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetExceptionByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Exception`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<string> GetExceptionByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Exception`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "auditLogID">GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetStatusByPK(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Status`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		public async Task<int> GetStatusByPKAsync(string auditLogID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditLogID", auditLogID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Status`", "`AuditLogID` = @AuditLogID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByCashAuditID
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID)
		{
			return GetByCashAuditID(cashAuditID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID)
		{
			return await GetByCashAuditIDAsync(cashAuditID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, TransactionManager tm_)
		{
			return GetByCashAuditID(cashAuditID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, TransactionManager tm_)
		{
			return await GetByCashAuditIDAsync(cashAuditID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, int top_)
		{
			return GetByCashAuditID(cashAuditID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, int top_)
		{
			return await GetByCashAuditIDAsync(cashAuditID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, int top_, TransactionManager tm_)
		{
			return GetByCashAuditID(cashAuditID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, int top_, TransactionManager tm_)
		{
			return await GetByCashAuditIDAsync(cashAuditID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, string sort_)
		{
			return GetByCashAuditID(cashAuditID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, string sort_)
		{
			return await GetByCashAuditIDAsync(cashAuditID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, string sort_, TransactionManager tm_)
		{
			return GetByCashAuditID(cashAuditID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, string sort_, TransactionManager tm_)
		{
			return await GetByCashAuditIDAsync(cashAuditID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashAuditID（字段） 查询
		/// </summary>
		/// /// <param name = "cashAuditID">主键guid</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByCashAuditID(string cashAuditID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(cashAuditID != null ? "`CashAuditID` = @CashAuditID" : "`CashAuditID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (cashAuditID != null)
				paras_.Add(Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByCashAuditIDAsync(string cashAuditID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(cashAuditID != null ? "`CashAuditID` = @CashAuditID" : "`CashAuditID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (cashAuditID != null)
				paras_.Add(Database.CreateInParameter("@CashAuditID", cashAuditID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByCashAuditID
		#region GetByAction
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action)
		{
			return GetByAction(action, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action)
		{
			return await GetByActionAsync(action, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, TransactionManager tm_)
		{
			return GetByAction(action, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, TransactionManager tm_)
		{
			return await GetByActionAsync(action, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, int top_)
		{
			return GetByAction(action, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, int top_)
		{
			return await GetByActionAsync(action, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, int top_, TransactionManager tm_)
		{
			return GetByAction(action, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, int top_, TransactionManager tm_)
		{
			return await GetByActionAsync(action, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, string sort_)
		{
			return GetByAction(action, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, string sort_)
		{
			return await GetByActionAsync(action, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, string sort_, TransactionManager tm_)
		{
			return GetByAction(action, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, string sort_, TransactionManager tm_)
		{
			return await GetByActionAsync(action, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Action（字段） 查询
		/// </summary>
		/// /// <param name = "action">操作0-提交申请1-审批通过2-审批拒绝</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByAction(int action, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Action` = @Action", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Action", action, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByActionAsync(int action, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Action` = @Action", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Action", action, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByAction
		#region GetByOperatorId
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId)
		{
			return GetByOperatorId(operatorId, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId)
		{
			return await GetByOperatorIdAsync(operatorId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, TransactionManager tm_)
		{
			return GetByOperatorId(operatorId, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, TransactionManager tm_)
		{
			return await GetByOperatorIdAsync(operatorId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, int top_)
		{
			return GetByOperatorId(operatorId, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, int top_)
		{
			return await GetByOperatorIdAsync(operatorId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, int top_, TransactionManager tm_)
		{
			return GetByOperatorId(operatorId, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIdAsync(operatorId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, string sort_)
		{
			return GetByOperatorId(operatorId, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, string sort_)
		{
			return await GetByOperatorIdAsync(operatorId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, string sort_, TransactionManager tm_)
		{
			return GetByOperatorId(operatorId, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, string sort_, TransactionManager tm_)
		{
			return await GetByOperatorIdAsync(operatorId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OperatorId（字段） 查询
		/// </summary>
		/// /// <param name = "operatorId">操作人ID</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorId(string operatorId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorId` = @OperatorId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorIdAsync(string operatorId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorId` = @OperatorId", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorId", operatorId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByOperatorId
		#region GetByOperatorName
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName)
		{
			return GetByOperatorName(operatorName, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName)
		{
			return await GetByOperatorNameAsync(operatorName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, TransactionManager tm_)
		{
			return GetByOperatorName(operatorName, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, TransactionManager tm_)
		{
			return await GetByOperatorNameAsync(operatorName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, int top_)
		{
			return GetByOperatorName(operatorName, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, int top_)
		{
			return await GetByOperatorNameAsync(operatorName, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, int top_, TransactionManager tm_)
		{
			return GetByOperatorName(operatorName, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, int top_, TransactionManager tm_)
		{
			return await GetByOperatorNameAsync(operatorName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, string sort_)
		{
			return GetByOperatorName(operatorName, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, string sort_)
		{
			return await GetByOperatorNameAsync(operatorName, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, string sort_, TransactionManager tm_)
		{
			return GetByOperatorName(operatorName, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, string sort_, TransactionManager tm_)
		{
			return await GetByOperatorNameAsync(operatorName, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OperatorName（字段） 查询
		/// </summary>
		/// /// <param name = "operatorName">操作人</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByOperatorName(string operatorName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorName` = @OperatorName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByOperatorNameAsync(string operatorName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorName` = @OperatorName", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorName", operatorName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByOperatorName
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_audit_logEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByTransType
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType)
		{
			return GetByTransType(transType, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType)
		{
			return await GetByTransTypeAsync(transType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, TransactionManager tm_)
		{
			return GetByTransType(transType, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, TransactionManager tm_)
		{
			return await GetByTransTypeAsync(transType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, int top_)
		{
			return GetByTransType(transType, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, int top_)
		{
			return await GetByTransTypeAsync(transType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, int top_, TransactionManager tm_)
		{
			return GetByTransType(transType, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, int top_, TransactionManager tm_)
		{
			return await GetByTransTypeAsync(transType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, string sort_)
		{
			return GetByTransType(transType, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, string sort_)
		{
			return await GetByTransTypeAsync(transType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, string sort_, TransactionManager tm_)
		{
			return GetByTransType(transType, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, string sort_, TransactionManager tm_)
		{
			return await GetByTransTypeAsync(transType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TransType（字段） 查询
		/// </summary>
		/// /// <param name = "transType">通讯类型(0-我方发起1-对方发起)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransType(int transType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TransType` = @TransType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransTypeAsync(int transType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TransType` = @TransType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TransType", transType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByTransType
		#region GetByTransMark
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark)
		{
			return GetByTransMark(transMark, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark)
		{
			return await GetByTransMarkAsync(transMark, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, TransactionManager tm_)
		{
			return GetByTransMark(transMark, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, TransactionManager tm_)
		{
			return await GetByTransMarkAsync(transMark, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, int top_)
		{
			return GetByTransMark(transMark, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, int top_)
		{
			return await GetByTransMarkAsync(transMark, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, int top_, TransactionManager tm_)
		{
			return GetByTransMark(transMark, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, int top_, TransactionManager tm_)
		{
			return await GetByTransMarkAsync(transMark, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, string sort_)
		{
			return GetByTransMark(transMark, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, string sort_)
		{
			return await GetByTransMarkAsync(transMark, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, string sort_, TransactionManager tm_)
		{
			return GetByTransMark(transMark, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, string sort_, TransactionManager tm_)
		{
			return await GetByTransMarkAsync(transMark, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TransMark（字段） 查询
		/// </summary>
		/// /// <param name = "transMark">通讯标记（接口标识）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByTransMark(string transMark, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(transMark != null ? "`TransMark` = @TransMark" : "`TransMark` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (transMark != null)
				paras_.Add(Database.CreateInParameter("@TransMark", transMark, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByTransMarkAsync(string transMark, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(transMark != null ? "`TransMark` = @TransMark" : "`TransMark` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (transMark != null)
				paras_.Add(Database.CreateInParameter("@TransMark", transMark, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByTransMark
		#region GetByRequestBody
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody)
		{
			return GetByRequestBody(requestBody, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody)
		{
			return await GetByRequestBodyAsync(requestBody, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, TransactionManager tm_)
		{
			return GetByRequestBody(requestBody, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, TransactionManager tm_)
		{
			return await GetByRequestBodyAsync(requestBody, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, int top_)
		{
			return GetByRequestBody(requestBody, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, int top_)
		{
			return await GetByRequestBodyAsync(requestBody, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, int top_, TransactionManager tm_)
		{
			return GetByRequestBody(requestBody, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, int top_, TransactionManager tm_)
		{
			return await GetByRequestBodyAsync(requestBody, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, string sort_)
		{
			return GetByRequestBody(requestBody, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, string sort_)
		{
			return await GetByRequestBodyAsync(requestBody, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, string sort_, TransactionManager tm_)
		{
			return GetByRequestBody(requestBody, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, string sort_, TransactionManager tm_)
		{
			return await GetByRequestBodyAsync(requestBody, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RequestBody（字段） 查询
		/// </summary>
		/// /// <param name = "requestBody">请求消息（我方请求或对方push）json</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestBody(string requestBody, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestBody != null ? "`RequestBody` = @RequestBody" : "`RequestBody` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestBody != null)
				paras_.Add(Database.CreateInParameter("@RequestBody", requestBody, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestBodyAsync(string requestBody, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(requestBody != null ? "`RequestBody` = @RequestBody" : "`RequestBody` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (requestBody != null)
				paras_.Add(Database.CreateInParameter("@RequestBody", requestBody, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByRequestBody
		#region GetByRequestTime
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime)
		{
			return GetByRequestTime(requestTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime)
		{
			return await GetByRequestTimeAsync(requestTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, int top_)
		{
			return GetByRequestTime(requestTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, int top_)
		{
			return await GetByRequestTimeAsync(requestTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, int top_, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, int top_, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, string sort_)
		{
			return GetByRequestTime(requestTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, string sort_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, string sort_, TransactionManager tm_)
		{
			return GetByRequestTime(requestTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, string sort_, TransactionManager tm_)
		{
			return await GetByRequestTimeAsync(requestTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RequestTime（字段） 查询
		/// </summary>
		/// /// <param name = "requestTime">请求时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByRequestTime(DateTime requestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RequestTime` = @RequestTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByRequestTimeAsync(DateTime requestTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RequestTime` = @RequestTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequestTime", requestTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByRequestTime
		#region GetByResponseTime
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime)
		{
			return GetByResponseTime(responseTime, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime)
		{
			return await GetByResponseTimeAsync(responseTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, TransactionManager tm_)
		{
			return await GetByResponseTimeAsync(responseTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, int top_)
		{
			return GetByResponseTime(responseTime, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_)
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
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, int top_, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_, TransactionManager tm_)
		{
			return await GetByResponseTimeAsync(responseTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseTime（字段） 查询
		/// </summary>
		/// /// <param name = "responseTime">返回时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, string sort_)
		{
			return GetByResponseTime(responseTime, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, string sort_)
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
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, string sort_, TransactionManager tm_)
		{
			return GetByResponseTime(responseTime, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_audit_logEO> GetByResponseTime(DateTime? responseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseTime.HasValue ? "`ResponseTime` = @ResponseTime" : "`ResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@ResponseTime", responseTime.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseTimeAsync(DateTime? responseTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseTime.HasValue ? "`ResponseTime` = @ResponseTime" : "`ResponseTime` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseTime.HasValue)
				paras_.Add(Database.CreateInParameter("@ResponseTime", responseTime.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByResponseTime
		#region GetByResponseBody
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody)
		{
			return GetByResponseBody(responseBody, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody)
		{
			return await GetByResponseBodyAsync(responseBody, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, TransactionManager tm_)
		{
			return GetByResponseBody(responseBody, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, TransactionManager tm_)
		{
			return await GetByResponseBodyAsync(responseBody, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, int top_)
		{
			return GetByResponseBody(responseBody, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, int top_)
		{
			return await GetByResponseBodyAsync(responseBody, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, int top_, TransactionManager tm_)
		{
			return GetByResponseBody(responseBody, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, int top_, TransactionManager tm_)
		{
			return await GetByResponseBodyAsync(responseBody, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, string sort_)
		{
			return GetByResponseBody(responseBody, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, string sort_)
		{
			return await GetByResponseBodyAsync(responseBody, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, string sort_, TransactionManager tm_)
		{
			return GetByResponseBody(responseBody, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, string sort_, TransactionManager tm_)
		{
			return await GetByResponseBodyAsync(responseBody, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ResponseBody（字段） 查询
		/// </summary>
		/// /// <param name = "responseBody">响应消息（对方响应或我方响应）json</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByResponseBody(string responseBody, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseBody != null ? "`ResponseBody` = @ResponseBody" : "`ResponseBody` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseBody != null)
				paras_.Add(Database.CreateInParameter("@ResponseBody", responseBody, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByResponseBodyAsync(string responseBody, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(responseBody != null ? "`ResponseBody` = @ResponseBody" : "`ResponseBody` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (responseBody != null)
				paras_.Add(Database.CreateInParameter("@ResponseBody", responseBody, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByResponseBody
		#region GetByException
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception)
		{
			return GetByException(exception, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception)
		{
			return await GetByExceptionAsync(exception, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, TransactionManager tm_)
		{
			return GetByException(exception, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, TransactionManager tm_)
		{
			return await GetByExceptionAsync(exception, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, int top_)
		{
			return GetByException(exception, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, int top_)
		{
			return await GetByExceptionAsync(exception, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, int top_, TransactionManager tm_)
		{
			return GetByException(exception, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, int top_, TransactionManager tm_)
		{
			return await GetByExceptionAsync(exception, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, string sort_)
		{
			return GetByException(exception, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, string sort_)
		{
			return await GetByExceptionAsync(exception, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, string sort_, TransactionManager tm_)
		{
			return GetByException(exception, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, string sort_, TransactionManager tm_)
		{
			return await GetByExceptionAsync(exception, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Exception（字段） 查询
		/// </summary>
		/// /// <param name = "exception">异常消息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByException(string exception, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(exception != null ? "`Exception` = @Exception" : "`Exception` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (exception != null)
				paras_.Add(Database.CreateInParameter("@Exception", exception, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByExceptionAsync(string exception, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(exception != null ? "`Exception` = @Exception" : "`Exception` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (exception != null)
				paras_.Add(Database.CreateInParameter("@Exception", exception, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByException
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">消息状态</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_audit_logEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		public async Task<List<Sc_cash_audit_logEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_audit_logEO.MapDataReader);
		}
		#endregion // GetByStatus
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
