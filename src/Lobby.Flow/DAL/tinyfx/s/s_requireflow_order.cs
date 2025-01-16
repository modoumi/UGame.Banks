/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-03-15 11: 50:24
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
	/// 流水需求订单
	/// 【表 s_requireflow_order 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class S_requireflow_orderEO : IRowMapper<S_requireflow_orderEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public S_requireflow_orderEO()
		{
			this.UserKind = 0;
			this.FromMode = 0;
			this.CurrencyType = 0;
			this.BonusSourceType = 1;
			this.IsBonus = false;
			this.OrderAmount = 0;
			this.FlowMultip = 0f;
			this.RequireFlow = 0;
			this.EndBalance = 0;
			this.EndBonus = 0;
			this.Status = 0;
			this.RecDate = DateTime.Now;
			this.OrderRemain = 0;
			this.InheritOrder = 0;
			this.CompletedFlow = 0;
			this.InheritFlow = 0;
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
		/// 充值及赠金时生成订单GUID
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
		/// 用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 6)]
		public int UserKind { get; set; }
		/// <summary>
		/// 新用户来源方式
		///              0-获得运营商的新用户(s_operator)
		///              1-推广员获得的新用户（userid）
		///              2-推广渠道通过url获得的新用户（s_channel_url)
		///              3-推广渠道通过code获得的新用户（s_channel_code)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 7)]
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
		[DataMember(Order = 8)]
		public string FromId { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 9)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币类型（货币缩写RMB,USD）
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 10)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 11)]
		public int CurrencyType { get; set; }
		/// <summary>
		/// 变化原因
		/// 【字段 varchar(255)】
		/// </summary>
		[DataMember(Order = 12)]
		public string BonusReason { get; set; }
		/// <summary>
		/// 0-未知1xxx-运营活动4xxx充值
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 13)]
		public int BonusSourceType { get; set; }
		/// <summary>
		/// 源表名
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 14)]
		public string SourceTable { get; set; }
		/// <summary>
		/// 源表编码
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 15)]
		public string SourceId { get; set; }
		/// <summary>
		/// 是否赠金
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 16)]
		public bool IsBonus { get; set; }
		/// <summary>
		/// 当前订单充值或获赠的金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 17)]
		public long OrderAmount { get; set; }
		/// <summary>
		/// 要求的流水系数
		/// 【字段 float】
		/// </summary>
		[DataMember(Order = 18)]
		public float FlowMultip { get; set; }
		/// <summary>
		/// 提现所要达到的流水
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 19)]
		public long RequireFlow { get; set; }
		/// <summary>
		/// 处理后余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 20)]
		public long EndBalance { get; set; }
		/// <summary>
		/// 处理后的bonus余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 21)]
		public long EndBonus { get; set; }
		/// <summary>
		/// 状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 22)]
		public int Status { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 23)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// 订单修改时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 24)]
		public DateTime UpdateTime { get; set; }
		/// <summary>
		/// 当前订单剩余金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 25)]
		public long OrderRemain { get; set; }
		/// <summary>
		/// 被继承的余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 26)]
		public long InheritOrder { get; set; }
		/// <summary>
		/// 当前已完成的流水
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 27)]
		public long CompletedFlow { get; set; }
		/// <summary>
		/// 被继承的流水
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 28)]
		public long InheritFlow { get; set; }
		/// <summary>
		/// 完成流水后bonus余额列表，|分割
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 29)]
		public string EndBonusList { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public S_requireflow_orderEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static S_requireflow_orderEO MapDataReader(IDataReader reader)
		{
		    S_requireflow_orderEO ret = new S_requireflow_orderEO();
			ret.OrderID = reader.ToString("OrderID");
			ret.OriginalOrderID = ret.OrderID;
			ret.ProviderID = reader.ToString("ProviderID");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.UserID = reader.ToString("UserID");
			ret.UserKind = reader.ToInt32("UserKind");
			ret.FromMode = reader.ToInt32("FromMode");
			ret.FromId = reader.ToString("FromId");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.CurrencyType = reader.ToInt32("CurrencyType");
			ret.BonusReason = reader.ToString("BonusReason");
			ret.BonusSourceType = reader.ToInt32("BonusSourceType");
			ret.SourceTable = reader.ToString("SourceTable");
			ret.SourceId = reader.ToString("SourceId");
			ret.IsBonus = reader.ToBoolean("IsBonus");
			ret.OrderAmount = reader.ToInt64("OrderAmount");
			ret.FlowMultip = reader.ToSingle("FlowMultip");
			ret.RequireFlow = reader.ToInt64("RequireFlow");
			ret.EndBalance = reader.ToInt64("EndBalance");
			ret.EndBonus = reader.ToInt64("EndBonus");
			ret.Status = reader.ToInt32("Status");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.UpdateTime = reader.ToDateTime("UpdateTime");
			ret.OrderRemain = reader.ToInt64("OrderRemain");
			ret.InheritOrder = reader.ToInt64("InheritOrder");
			ret.CompletedFlow = reader.ToInt64("CompletedFlow");
			ret.InheritFlow = reader.ToInt64("InheritFlow");
			ret.EndBonusList = reader.ToString("EndBonusList");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 流水需求订单
	/// 【表 s_requireflow_order 的操作类】
	/// </summary>
	[Obsolete]
	public class S_requireflow_orderMO : MySqlTableMO<S_requireflow_orderEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`s_requireflow_order`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public S_requireflow_orderMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public S_requireflow_orderMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public S_requireflow_orderMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(S_requireflow_orderEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(S_requireflow_orderEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(S_requireflow_orderEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OrderID`, `ProviderID`, `AppID`, `OperatorID`, `UserID`, `UserKind`, `FromMode`, `FromId`, `CountryID`, `CurrencyID`, `CurrencyType`, `BonusReason`, `BonusSourceType`, `SourceTable`, `SourceId`, `IsBonus`, `OrderAmount`, `FlowMultip`, `RequireFlow`, `EndBalance`, `EndBonus`, `Status`, `RecDate`, `UpdateTime`, `OrderRemain`, `InheritOrder`, `CompletedFlow`, `InheritFlow`, `EndBonusList`) VALUE (@OrderID, @ProviderID, @AppID, @OperatorID, @UserID, @UserKind, @FromMode, @FromId, @CountryID, @CurrencyID, @CurrencyType, @BonusReason, @BonusSourceType, @SourceTable, @SourceId, @IsBonus, @OrderAmount, @FlowMultip, @RequireFlow, @EndBalance, @EndBonus, @Status, @RecDate, @UpdateTime, @OrderRemain, @InheritOrder, @CompletedFlow, @InheritFlow, @EndBonusList);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", item.OrderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID != null ? item.ProviderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID != null ? item.UserID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyType", item.CurrencyType, MySqlDbType.Int32),
				Database.CreateInParameter("@BonusReason", item.BonusReason != null ? item.BonusReason : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BonusSourceType", item.BonusSourceType, MySqlDbType.Int32),
				Database.CreateInParameter("@SourceTable", item.SourceTable != null ? item.SourceTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SourceId", item.SourceId != null ? item.SourceId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsBonus", item.IsBonus, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderAmount", item.OrderAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@RequireFlow", item.RequireFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBalance", item.EndBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonus", item.EndBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@UpdateTime", item.UpdateTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderRemain", item.OrderRemain, MySqlDbType.Int64),
				Database.CreateInParameter("@InheritOrder", item.InheritOrder, MySqlDbType.Int64),
				Database.CreateInParameter("@CompletedFlow", item.CompletedFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@InheritFlow", item.InheritFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonusList", item.EndBonusList != null ? item.EndBonusList : (object)DBNull.Value, MySqlDbType.Text),
			};
		}
		public int AddByBatch(IEnumerable<S_requireflow_orderEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<S_requireflow_orderEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<S_requireflow_orderEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OrderID`, `ProviderID`, `AppID`, `OperatorID`, `UserID`, `UserKind`, `FromMode`, `FromId`, `CountryID`, `CurrencyID`, `CurrencyType`, `BonusReason`, `BonusSourceType`, `SourceTable`, `SourceId`, `IsBonus`, `OrderAmount`, `FlowMultip`, `RequireFlow`, `EndBalance`, `EndBonus`, `Status`, `RecDate`, `UpdateTime`, `OrderRemain`, `InheritOrder`, `CompletedFlow`, `InheritFlow`, `EndBonusList`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OrderID}','{item.ProviderID}','{item.AppID}','{item.OperatorID}','{item.UserID}',{item.UserKind},{item.FromMode},'{item.FromId}','{item.CountryID}','{item.CurrencyID}',{item.CurrencyType},'{item.BonusReason}',{item.BonusSourceType},'{item.SourceTable}','{item.SourceId}',{item.IsBonus},{item.OrderAmount},{item.FlowMultip},{item.RequireFlow},{item.EndBalance},{item.EndBonus},{item.Status},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}','{item.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")}',{item.OrderRemain},{item.InheritOrder},{item.CompletedFlow},{item.InheritFlow},'{item.EndBonusList}'),");
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		public int Remove(S_requireflow_orderEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OrderID, tm_);
		}
		public async Task<int> RemoveAsync(S_requireflow_orderEO item, TransactionManager tm_ = null)
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
			sql_ = $"DELETE FROM {TableName} WHERE " + (userID != null ? "`UserID` = @UserID" : "`UserID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (userID != null)
				paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByUserID
		#region RemoveByUserKind
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
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
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
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
		#region RemoveByCurrencyType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCurrencyType(int currencyType, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyTypeData(currencyType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCurrencyTypeAsync(int currencyType, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyTypeData(currencyType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCurrencyTypeData(int currencyType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CurrencyType` = @CurrencyType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32));
		}
		#endregion // RemoveByCurrencyType
		#region RemoveByBonusReason
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBonusReason(string bonusReason, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusReasonData(bonusReason, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBonusReasonAsync(string bonusReason, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusReasonData(bonusReason, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBonusReasonData(string bonusReason, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bonusReason != null ? "`BonusReason` = @BonusReason" : "`BonusReason` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bonusReason != null)
				paras_.Add(Database.CreateInParameter("@BonusReason", bonusReason, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBonusReason
		#region RemoveByBonusSourceType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBonusSourceType(int bonusSourceType, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusSourceTypeData(bonusSourceType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBonusSourceTypeAsync(int bonusSourceType, TransactionManager tm_ = null)
		{
			RepairRemoveByBonusSourceTypeData(bonusSourceType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBonusSourceTypeData(int bonusSourceType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BonusSourceType` = @BonusSourceType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32));
		}
		#endregion // RemoveByBonusSourceType
		#region RemoveBySourceTable
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySourceTable(string sourceTable, TransactionManager tm_ = null)
		{
			RepairRemoveBySourceTableData(sourceTable, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySourceTableAsync(string sourceTable, TransactionManager tm_ = null)
		{
			RepairRemoveBySourceTableData(sourceTable, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySourceTableData(string sourceTable, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (sourceTable != null ? "`SourceTable` = @SourceTable" : "`SourceTable` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (sourceTable != null)
				paras_.Add(Database.CreateInParameter("@SourceTable", sourceTable, MySqlDbType.VarChar));
		}
		#endregion // RemoveBySourceTable
		#region RemoveBySourceId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveBySourceId(string sourceId, TransactionManager tm_ = null)
		{
			RepairRemoveBySourceIdData(sourceId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveBySourceIdAsync(string sourceId, TransactionManager tm_ = null)
		{
			RepairRemoveBySourceIdData(sourceId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveBySourceIdData(string sourceId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (sourceId != null ? "`SourceId` = @SourceId" : "`SourceId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (sourceId != null)
				paras_.Add(Database.CreateInParameter("@SourceId", sourceId, MySqlDbType.VarChar));
		}
		#endregion // RemoveBySourceId
		#region RemoveByIsBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsBonus(bool isBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByIsBonusData(isBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsBonusAsync(bool isBonus, TransactionManager tm_ = null)
		{
			RepairRemoveByIsBonusData(isBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsBonusData(bool isBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsBonus` = @IsBonus";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsBonus
		#region RemoveByOrderAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderAmount(long orderAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderAmountData(orderAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderAmountAsync(long orderAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderAmountData(orderAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderAmountData(long orderAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderAmount` = @OrderAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByOrderAmount
		#region RemoveByFlowMultip
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFlowMultip(float flowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByFlowMultipData(flowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFlowMultipAsync(float flowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByFlowMultipData(flowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFlowMultipData(float flowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `FlowMultip` = @FlowMultip";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
		}
		#endregion // RemoveByFlowMultip
		#region RemoveByRequireFlow
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRequireFlow(long requireFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByRequireFlowData(requireFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRequireFlowAsync(long requireFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByRequireFlowData(requireFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRequireFlowData(long requireFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RequireFlow` = @RequireFlow";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64));
		}
		#endregion // RemoveByRequireFlow
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
		#region RemoveByEndBonus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
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
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
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
		#region RemoveByUpdateTime
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUpdateTime(DateTime updateTime, TransactionManager tm_ = null)
		{
			RepairRemoveByUpdateTimeData(updateTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUpdateTimeAsync(DateTime updateTime, TransactionManager tm_ = null)
		{
			RepairRemoveByUpdateTimeData(updateTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUpdateTimeData(DateTime updateTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UpdateTime` = @UpdateTime";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime));
		}
		#endregion // RemoveByUpdateTime
		#region RemoveByOrderRemain
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderRemain(long orderRemain, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderRemainData(orderRemain, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderRemainAsync(long orderRemain, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderRemainData(orderRemain, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderRemainData(long orderRemain, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderRemain` = @OrderRemain";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64));
		}
		#endregion // RemoveByOrderRemain
		#region RemoveByInheritOrder
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByInheritOrder(long inheritOrder, TransactionManager tm_ = null)
		{
			RepairRemoveByInheritOrderData(inheritOrder, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByInheritOrderAsync(long inheritOrder, TransactionManager tm_ = null)
		{
			RepairRemoveByInheritOrderData(inheritOrder, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByInheritOrderData(long inheritOrder, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `InheritOrder` = @InheritOrder";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64));
		}
		#endregion // RemoveByInheritOrder
		#region RemoveByCompletedFlow
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCompletedFlow(long completedFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByCompletedFlowData(completedFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCompletedFlowAsync(long completedFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByCompletedFlowData(completedFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCompletedFlowData(long completedFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CompletedFlow` = @CompletedFlow";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64));
		}
		#endregion // RemoveByCompletedFlow
		#region RemoveByInheritFlow
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByInheritFlow(long inheritFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByInheritFlowData(inheritFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByInheritFlowAsync(long inheritFlow, TransactionManager tm_ = null)
		{
			RepairRemoveByInheritFlowData(inheritFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByInheritFlowData(long inheritFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `InheritFlow` = @InheritFlow";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64));
		}
		#endregion // RemoveByInheritFlow
		#region RemoveByEndBonusList
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByEndBonusList(string endBonusList, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBonusListData(endBonusList, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByEndBonusListAsync(string endBonusList, TransactionManager tm_ = null)
		{
			RepairRemoveByEndBonusListData(endBonusList, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByEndBonusListData(string endBonusList, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (endBonusList != null ? "`EndBonusList` = @EndBonusList" : "`EndBonusList` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (endBonusList != null)
				paras_.Add(Database.CreateInParameter("@EndBonusList", endBonusList, MySqlDbType.Text));
		}
		#endregion // RemoveByEndBonusList
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
		public int Put(S_requireflow_orderEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(S_requireflow_orderEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(S_requireflow_orderEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderID` = @OrderID, `ProviderID` = @ProviderID, `AppID` = @AppID, `OperatorID` = @OperatorID, `UserID` = @UserID, `UserKind` = @UserKind, `FromMode` = @FromMode, `FromId` = @FromId, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `CurrencyType` = @CurrencyType, `BonusReason` = @BonusReason, `BonusSourceType` = @BonusSourceType, `SourceTable` = @SourceTable, `SourceId` = @SourceId, `IsBonus` = @IsBonus, `OrderAmount` = @OrderAmount, `FlowMultip` = @FlowMultip, `RequireFlow` = @RequireFlow, `EndBalance` = @EndBalance, `EndBonus` = @EndBonus, `Status` = @Status, `UpdateTime` = @UpdateTime, `OrderRemain` = @OrderRemain, `InheritOrder` = @InheritOrder, `CompletedFlow` = @CompletedFlow, `InheritFlow` = @InheritFlow, `EndBonusList` = @EndBonusList WHERE `OrderID` = @OrderID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", item.OrderID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ProviderID", item.ProviderID != null ? item.ProviderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", item.UserID != null ? item.UserID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserKind", item.UserKind, MySqlDbType.Int32),
				Database.CreateInParameter("@FromMode", item.FromMode, MySqlDbType.Int32),
				Database.CreateInParameter("@FromId", item.FromId != null ? item.FromId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyType", item.CurrencyType, MySqlDbType.Int32),
				Database.CreateInParameter("@BonusReason", item.BonusReason != null ? item.BonusReason : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BonusSourceType", item.BonusSourceType, MySqlDbType.Int32),
				Database.CreateInParameter("@SourceTable", item.SourceTable != null ? item.SourceTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SourceId", item.SourceId != null ? item.SourceId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsBonus", item.IsBonus, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderAmount", item.OrderAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@FlowMultip", item.FlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@RequireFlow", item.RequireFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBalance", item.EndBalance, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonus", item.EndBonus, MySqlDbType.Int64),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@UpdateTime", item.UpdateTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderRemain", item.OrderRemain, MySqlDbType.Int64),
				Database.CreateInParameter("@InheritOrder", item.InheritOrder, MySqlDbType.Int64),
				Database.CreateInParameter("@CompletedFlow", item.CompletedFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@InheritFlow", item.InheritFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@EndBonusList", item.EndBonusList != null ? item.EndBonusList : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OrderID_Original", item.HasOriginal ? item.OriginalOrderID : item.OrderID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<S_requireflow_orderEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<S_requireflow_orderEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
				Database.CreateInParameter("@UserID", userID != null ? userID : (object)DBNull.Value, MySqlDbType.VarChar),
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
			var parameter_ = Database.CreateInParameter("@UserID", userID != null ? userID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUserIDAsync(string userID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UserID` = @UserID";
			var parameter_ = Database.CreateInParameter("@UserID", userID != null ? userID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUserID
		#region PutUserKind
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
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
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		#region PutCountryID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		#region PutCurrencyID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
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
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
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
		#region PutCurrencyType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyTypeByPK(string orderID, int currencyType, TransactionManager tm_ = null)
		{
			RepairPutCurrencyTypeByPKData(orderID, currencyType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyTypeByPKAsync(string orderID, int currencyType, TransactionManager tm_ = null)
		{
			RepairPutCurrencyTypeByPKData(orderID, currencyType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyTypeByPKData(string orderID, int currencyType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyType` = @CurrencyType  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyType(int currencyType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyType` = @CurrencyType";
			var parameter_ = Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrencyTypeAsync(int currencyType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyType` = @CurrencyType";
			var parameter_ = Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrencyType
		#region PutBonusReason
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonusReasonByPK(string orderID, string bonusReason, TransactionManager tm_ = null)
		{
			RepairPutBonusReasonByPKData(orderID, bonusReason, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBonusReasonByPKAsync(string orderID, string bonusReason, TransactionManager tm_ = null)
		{
			RepairPutBonusReasonByPKData(orderID, bonusReason, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBonusReasonByPKData(string orderID, string bonusReason, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BonusReason` = @BonusReason  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BonusReason", bonusReason != null ? bonusReason : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonusReason(string bonusReason, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BonusReason` = @BonusReason";
			var parameter_ = Database.CreateInParameter("@BonusReason", bonusReason != null ? bonusReason : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBonusReasonAsync(string bonusReason, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BonusReason` = @BonusReason";
			var parameter_ = Database.CreateInParameter("@BonusReason", bonusReason != null ? bonusReason : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBonusReason
		#region PutBonusSourceType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonusSourceTypeByPK(string orderID, int bonusSourceType, TransactionManager tm_ = null)
		{
			RepairPutBonusSourceTypeByPKData(orderID, bonusSourceType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBonusSourceTypeByPKAsync(string orderID, int bonusSourceType, TransactionManager tm_ = null)
		{
			RepairPutBonusSourceTypeByPKData(orderID, bonusSourceType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBonusSourceTypeByPKData(string orderID, int bonusSourceType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BonusSourceType` = @BonusSourceType  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBonusSourceType(int bonusSourceType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BonusSourceType` = @BonusSourceType";
			var parameter_ = Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBonusSourceTypeAsync(int bonusSourceType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BonusSourceType` = @BonusSourceType";
			var parameter_ = Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBonusSourceType
		#region PutSourceTable
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSourceTableByPK(string orderID, string sourceTable, TransactionManager tm_ = null)
		{
			RepairPutSourceTableByPKData(orderID, sourceTable, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSourceTableByPKAsync(string orderID, string sourceTable, TransactionManager tm_ = null)
		{
			RepairPutSourceTableByPKData(orderID, sourceTable, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSourceTableByPKData(string orderID, string sourceTable, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SourceTable` = @SourceTable  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SourceTable", sourceTable != null ? sourceTable : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSourceTable(string sourceTable, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SourceTable` = @SourceTable";
			var parameter_ = Database.CreateInParameter("@SourceTable", sourceTable != null ? sourceTable : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSourceTableAsync(string sourceTable, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SourceTable` = @SourceTable";
			var parameter_ = Database.CreateInParameter("@SourceTable", sourceTable != null ? sourceTable : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSourceTable
		#region PutSourceId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSourceIdByPK(string orderID, string sourceId, TransactionManager tm_ = null)
		{
			RepairPutSourceIdByPKData(orderID, sourceId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutSourceIdByPKAsync(string orderID, string sourceId, TransactionManager tm_ = null)
		{
			RepairPutSourceIdByPKData(orderID, sourceId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutSourceIdByPKData(string orderID, string sourceId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SourceId` = @SourceId  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SourceId", sourceId != null ? sourceId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutSourceId(string sourceId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SourceId` = @SourceId";
			var parameter_ = Database.CreateInParameter("@SourceId", sourceId != null ? sourceId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutSourceIdAsync(string sourceId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `SourceId` = @SourceId";
			var parameter_ = Database.CreateInParameter("@SourceId", sourceId != null ? sourceId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutSourceId
		#region PutIsBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsBonusByPK(string orderID, bool isBonus, TransactionManager tm_ = null)
		{
			RepairPutIsBonusByPKData(orderID, isBonus, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsBonusByPKAsync(string orderID, bool isBonus, TransactionManager tm_ = null)
		{
			RepairPutIsBonusByPKData(orderID, isBonus, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsBonusByPKData(string orderID, bool isBonus, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsBonus(bool isBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus";
			var parameter_ = Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsBonusAsync(bool isBonus, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsBonus` = @IsBonus";
			var parameter_ = Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsBonus
		#region PutOrderAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderAmountByPK(string orderID, long orderAmount, TransactionManager tm_ = null)
		{
			RepairPutOrderAmountByPKData(orderID, orderAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderAmountByPKAsync(string orderID, long orderAmount, TransactionManager tm_ = null)
		{
			RepairPutOrderAmountByPKData(orderID, orderAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderAmountByPKData(string orderID, long orderAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderAmount` = @OrderAmount  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderAmount(long orderAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderAmount` = @OrderAmount";
			var parameter_ = Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderAmountAsync(long orderAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderAmount` = @OrderAmount";
			var parameter_ = Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderAmount
		#region PutFlowMultip
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFlowMultipByPK(string orderID, float flowMultip, TransactionManager tm_ = null)
		{
			RepairPutFlowMultipByPKData(orderID, flowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFlowMultipByPKAsync(string orderID, float flowMultip, TransactionManager tm_ = null)
		{
			RepairPutFlowMultipByPKData(orderID, flowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFlowMultipByPKData(string orderID, float flowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFlowMultip(float flowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip";
			var parameter_ = Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFlowMultipAsync(float flowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FlowMultip` = @FlowMultip";
			var parameter_ = Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFlowMultip
		#region PutRequireFlow
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequireFlowByPK(string orderID, long requireFlow, TransactionManager tm_ = null)
		{
			RepairPutRequireFlowByPKData(orderID, requireFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRequireFlowByPKAsync(string orderID, long requireFlow, TransactionManager tm_ = null)
		{
			RepairPutRequireFlowByPKData(orderID, requireFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRequireFlowByPKData(string orderID, long requireFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RequireFlow` = @RequireFlow  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRequireFlow(long requireFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequireFlow` = @RequireFlow";
			var parameter_ = Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRequireFlowAsync(long requireFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RequireFlow` = @RequireFlow";
			var parameter_ = Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRequireFlow
		#region PutEndBalance
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		#region PutEndBonus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
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
		/// /// <param name = "endBonus">处理后的bonus余额</param>
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
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
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
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
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
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		#region PutUpdateTime
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUpdateTimeByPK(string orderID, DateTime updateTime, TransactionManager tm_ = null)
		{
			RepairPutUpdateTimeByPKData(orderID, updateTime, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUpdateTimeByPKAsync(string orderID, DateTime updateTime, TransactionManager tm_ = null)
		{
			RepairPutUpdateTimeByPKData(orderID, updateTime, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUpdateTimeByPKData(string orderID, DateTime updateTime, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUpdateTime(DateTime updateTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime";
			var parameter_ = Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUpdateTimeAsync(DateTime updateTime, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UpdateTime` = @UpdateTime";
			var parameter_ = Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUpdateTime
		#region PutOrderRemain
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderRemainByPK(string orderID, long orderRemain, TransactionManager tm_ = null)
		{
			RepairPutOrderRemainByPKData(orderID, orderRemain, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderRemainByPKAsync(string orderID, long orderRemain, TransactionManager tm_ = null)
		{
			RepairPutOrderRemainByPKData(orderID, orderRemain, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderRemainByPKData(string orderID, long orderRemain, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderRemain` = @OrderRemain  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderRemain(long orderRemain, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderRemain` = @OrderRemain";
			var parameter_ = Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderRemainAsync(long orderRemain, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderRemain` = @OrderRemain";
			var parameter_ = Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderRemain
		#region PutInheritOrder
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutInheritOrderByPK(string orderID, long inheritOrder, TransactionManager tm_ = null)
		{
			RepairPutInheritOrderByPKData(orderID, inheritOrder, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutInheritOrderByPKAsync(string orderID, long inheritOrder, TransactionManager tm_ = null)
		{
			RepairPutInheritOrderByPKData(orderID, inheritOrder, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutInheritOrderByPKData(string orderID, long inheritOrder, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `InheritOrder` = @InheritOrder  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutInheritOrder(long inheritOrder, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `InheritOrder` = @InheritOrder";
			var parameter_ = Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutInheritOrderAsync(long inheritOrder, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `InheritOrder` = @InheritOrder";
			var parameter_ = Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutInheritOrder
		#region PutCompletedFlow
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCompletedFlowByPK(string orderID, long completedFlow, TransactionManager tm_ = null)
		{
			RepairPutCompletedFlowByPKData(orderID, completedFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCompletedFlowByPKAsync(string orderID, long completedFlow, TransactionManager tm_ = null)
		{
			RepairPutCompletedFlowByPKData(orderID, completedFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCompletedFlowByPKData(string orderID, long completedFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CompletedFlow` = @CompletedFlow  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCompletedFlow(long completedFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CompletedFlow` = @CompletedFlow";
			var parameter_ = Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCompletedFlowAsync(long completedFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CompletedFlow` = @CompletedFlow";
			var parameter_ = Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCompletedFlow
		#region PutInheritFlow
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutInheritFlowByPK(string orderID, long inheritFlow, TransactionManager tm_ = null)
		{
			RepairPutInheritFlowByPKData(orderID, inheritFlow, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutInheritFlowByPKAsync(string orderID, long inheritFlow, TransactionManager tm_ = null)
		{
			RepairPutInheritFlowByPKData(orderID, inheritFlow, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutInheritFlowByPKData(string orderID, long inheritFlow, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `InheritFlow` = @InheritFlow  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutInheritFlow(long inheritFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `InheritFlow` = @InheritFlow";
			var parameter_ = Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutInheritFlowAsync(long inheritFlow, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `InheritFlow` = @InheritFlow";
			var parameter_ = Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutInheritFlow
		#region PutEndBonusList
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBonusListByPK(string orderID, string endBonusList, TransactionManager tm_ = null)
		{
			RepairPutEndBonusListByPKData(orderID, endBonusList, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutEndBonusListByPKAsync(string orderID, string endBonusList, TransactionManager tm_ = null)
		{
			RepairPutEndBonusListByPKData(orderID, endBonusList, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutEndBonusListByPKData(string orderID, string endBonusList, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `EndBonusList` = @EndBonusList  WHERE `OrderID` = @OrderID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@EndBonusList", endBonusList != null ? endBonusList : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutEndBonusList(string endBonusList, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBonusList` = @EndBonusList";
			var parameter_ = Database.CreateInParameter("@EndBonusList", endBonusList != null ? endBonusList : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutEndBonusListAsync(string endBonusList, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `EndBonusList` = @EndBonusList";
			var parameter_ = Database.CreateInParameter("@EndBonusList", endBonusList != null ? endBonusList : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutEndBonusList
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(S_requireflow_orderEO item, TransactionManager tm = null)
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
		public async Task<bool> SetAsync(S_requireflow_orderEO item, TransactionManager tm = null)
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public S_requireflow_orderEO GetByPK(string orderID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(orderID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<S_requireflow_orderEO> GetByPKAsync(string orderID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(orderID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 UserKind（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 FromMode（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 CurrencyType（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetCurrencyTypeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`CurrencyType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetCurrencyTypeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`CurrencyType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BonusReason（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBonusReasonByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BonusReason`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetBonusReasonByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BonusReason`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BonusSourceType（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetBonusSourceTypeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`BonusSourceType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<int> GetBonusSourceTypeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`BonusSourceType`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SourceTable（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetSourceTableByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`SourceTable`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetSourceTableByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`SourceTable`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 SourceId（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetSourceIdByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`SourceId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetSourceIdByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`SourceId`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsBonus（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsBonusByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<bool> GetIsBonusByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsBonus`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderAmount（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetOrderAmountByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`OrderAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetOrderAmountByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`OrderAmount`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FlowMultip（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetFlowMultipByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (float)GetScalar("`FlowMultip`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<float> GetFlowMultipByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (float)await GetScalarAsync("`FlowMultip`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RequireFlow（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetRequireFlowByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`RequireFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetRequireFlowByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`RequireFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 EndBalance（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 EndBonus（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
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
		/// 按主键查询 UpdateTime（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetUpdateTimeByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`UpdateTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<DateTime> GetUpdateTimeByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`UpdateTime`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderRemain（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetOrderRemainByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`OrderRemain`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetOrderRemainByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`OrderRemain`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 InheritOrder（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetInheritOrderByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`InheritOrder`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetInheritOrderByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`InheritOrder`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CompletedFlow（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCompletedFlowByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CompletedFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetCompletedFlowByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CompletedFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 InheritFlow（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetInheritFlowByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`InheritFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<long> GetInheritFlowByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`InheritFlow`", "`OrderID` = @OrderID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 EndBonusList（字段）
		/// </summary>
		/// /// <param name = "orderID">充值及赠金时生成订单GUID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetEndBonusListByPK(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`EndBonusList`", "`OrderID` = @OrderID", paras_, tm_);
		}
		public async Task<string> GetEndBonusListByPKAsync(string orderID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`EndBonusList`", "`OrderID` = @OrderID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByProviderID
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByProviderID(string providerID)
		{
			return GetByProviderID(providerID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, int top_)
		{
			return GetByProviderID(providerID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, int top_)
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
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, int top_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, int top_, TransactionManager tm_)
		{
			return await GetByProviderIDAsync(providerID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ProviderID（字段） 查询
		/// </summary>
		/// /// <param name = "providerID">应用提供商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, string sort_)
		{
			return GetByProviderID(providerID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, string sort_)
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
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, string sort_, TransactionManager tm_)
		{
			return GetByProviderID(providerID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByProviderID(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(providerID != null ? "`ProviderID` = @ProviderID" : "`ProviderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (providerID != null)
				paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByProviderIDAsync(string providerID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(providerID != null ? "`ProviderID` = @ProviderID" : "`ProviderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (providerID != null)
				paras_.Add(Database.CreateInParameter("@ProviderID", providerID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByProviderID
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, int top_)
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
		public List<S_requireflow_orderEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, string sort_)
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
		public List<S_requireflow_orderEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, int top_)
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
		public List<S_requireflow_orderEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, string sort_)
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
		public List<S_requireflow_orderEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userID != null ? "`UserID` = @UserID" : "`UserID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userID != null)
				paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userID != null ? "`UserID` = @UserID" : "`UserID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userID != null)
				paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByUserID
		#region GetByUserKind
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind)
		{
			return GetByUserKind(userKind, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, int top_)
		{
			return GetByUserKind(userKind, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, int top_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, int top_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, int top_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, string sort_)
		{
			return GetByUserKind(userKind, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, string sort_)
		{
			return await GetByUserKindAsync(userKind, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, string sort_, TransactionManager tm_)
		{
			return GetByUserKind(userKind, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, string sort_, TransactionManager tm_)
		{
			return await GetByUserKindAsync(userKind, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UserKind（字段） 查询
		/// </summary>
		/// /// <param name = "userKind">用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUserKind(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUserKindAsync(int userKind, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UserKind` = @UserKind", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UserKind", userKind, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByUserKind
		#region GetByFromMode
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode)
		{
			return GetByFromMode(fromMode, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, int top_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, int top_)
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
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, int top_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, int top_, TransactionManager tm_)
		{
			return await GetByFromModeAsync(fromMode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromMode（字段） 查询
		/// </summary>
		/// /// <param name = "fromMode">新用户来源方式</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, string sort_)
		{
			return GetByFromMode(fromMode, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, string sort_)
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
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, string sort_, TransactionManager tm_)
		{
			return GetByFromMode(fromMode, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByFromMode(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromModeAsync(int fromMode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FromMode` = @FromMode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FromMode", fromMode, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByFromMode
		#region GetByFromId
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromId(string fromId)
		{
			return GetByFromId(fromId, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromId(string fromId, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromId(string fromId, int top_)
		{
			return GetByFromId(fromId, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, int top_)
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
		public List<S_requireflow_orderEO> GetByFromId(string fromId, int top_, TransactionManager tm_)
		{
			return GetByFromId(fromId, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, int top_, TransactionManager tm_)
		{
			return await GetByFromIdAsync(fromId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FromId（字段） 查询
		/// </summary>
		/// /// <param name = "fromId">对应的编码（根据FromMode变化）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFromId(string fromId, string sort_)
		{
			return GetByFromId(fromId, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, string sort_)
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
		public List<S_requireflow_orderEO> GetByFromId(string fromId, string sort_, TransactionManager tm_)
		{
			return GetByFromId(fromId, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByFromId(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFromIdAsync(string fromId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(fromId != null ? "`FromId` = @FromId" : "`FromId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (fromId != null)
				paras_.Add(Database.CreateInParameter("@FromId", fromId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByFromId
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型（货币缩写RMB,USD）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByCurrencyType
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType)
		{
			return GetByCurrencyType(currencyType, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType)
		{
			return await GetByCurrencyTypeAsync(currencyType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, TransactionManager tm_)
		{
			return GetByCurrencyType(currencyType, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, TransactionManager tm_)
		{
			return await GetByCurrencyTypeAsync(currencyType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, int top_)
		{
			return GetByCurrencyType(currencyType, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, int top_)
		{
			return await GetByCurrencyTypeAsync(currencyType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, int top_, TransactionManager tm_)
		{
			return GetByCurrencyType(currencyType, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyTypeAsync(currencyType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, string sort_)
		{
			return GetByCurrencyType(currencyType, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, string sort_)
		{
			return await GetByCurrencyTypeAsync(currencyType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyType(currencyType, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyTypeAsync(currencyType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyType（字段） 查询
		/// </summary>
		/// /// <param name = "currencyType">货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCurrencyType(int currencyType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyType` = @CurrencyType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCurrencyTypeAsync(int currencyType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyType` = @CurrencyType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyType", currencyType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByCurrencyType
		#region GetByBonusReason
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason)
		{
			return GetByBonusReason(bonusReason, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason)
		{
			return await GetByBonusReasonAsync(bonusReason, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, TransactionManager tm_)
		{
			return GetByBonusReason(bonusReason, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, TransactionManager tm_)
		{
			return await GetByBonusReasonAsync(bonusReason, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, int top_)
		{
			return GetByBonusReason(bonusReason, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, int top_)
		{
			return await GetByBonusReasonAsync(bonusReason, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, int top_, TransactionManager tm_)
		{
			return GetByBonusReason(bonusReason, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, int top_, TransactionManager tm_)
		{
			return await GetByBonusReasonAsync(bonusReason, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, string sort_)
		{
			return GetByBonusReason(bonusReason, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, string sort_)
		{
			return await GetByBonusReasonAsync(bonusReason, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, string sort_, TransactionManager tm_)
		{
			return GetByBonusReason(bonusReason, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, string sort_, TransactionManager tm_)
		{
			return await GetByBonusReasonAsync(bonusReason, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BonusReason（字段） 查询
		/// </summary>
		/// /// <param name = "bonusReason">变化原因</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusReason(string bonusReason, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bonusReason != null ? "`BonusReason` = @BonusReason" : "`BonusReason` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bonusReason != null)
				paras_.Add(Database.CreateInParameter("@BonusReason", bonusReason, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusReasonAsync(string bonusReason, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bonusReason != null ? "`BonusReason` = @BonusReason" : "`BonusReason` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bonusReason != null)
				paras_.Add(Database.CreateInParameter("@BonusReason", bonusReason, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByBonusReason
		#region GetByBonusSourceType
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType)
		{
			return GetByBonusSourceType(bonusSourceType, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, TransactionManager tm_)
		{
			return GetByBonusSourceType(bonusSourceType, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, TransactionManager tm_)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, int top_)
		{
			return GetByBonusSourceType(bonusSourceType, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, int top_)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, int top_, TransactionManager tm_)
		{
			return GetByBonusSourceType(bonusSourceType, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, int top_, TransactionManager tm_)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, string sort_)
		{
			return GetByBonusSourceType(bonusSourceType, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, string sort_)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, string sort_, TransactionManager tm_)
		{
			return GetByBonusSourceType(bonusSourceType, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, string sort_, TransactionManager tm_)
		{
			return await GetByBonusSourceTypeAsync(bonusSourceType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BonusSourceType（字段） 查询
		/// </summary>
		/// /// <param name = "bonusSourceType">0-未知1xxx-运营活动4xxx充值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByBonusSourceType(int bonusSourceType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BonusSourceType` = @BonusSourceType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByBonusSourceTypeAsync(int bonusSourceType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BonusSourceType` = @BonusSourceType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BonusSourceType", bonusSourceType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByBonusSourceType
		#region GetBySourceTable
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable)
		{
			return GetBySourceTable(sourceTable, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable)
		{
			return await GetBySourceTableAsync(sourceTable, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, TransactionManager tm_)
		{
			return GetBySourceTable(sourceTable, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, TransactionManager tm_)
		{
			return await GetBySourceTableAsync(sourceTable, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, int top_)
		{
			return GetBySourceTable(sourceTable, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, int top_)
		{
			return await GetBySourceTableAsync(sourceTable, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, int top_, TransactionManager tm_)
		{
			return GetBySourceTable(sourceTable, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, int top_, TransactionManager tm_)
		{
			return await GetBySourceTableAsync(sourceTable, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, string sort_)
		{
			return GetBySourceTable(sourceTable, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, string sort_)
		{
			return await GetBySourceTableAsync(sourceTable, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, string sort_, TransactionManager tm_)
		{
			return GetBySourceTable(sourceTable, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, string sort_, TransactionManager tm_)
		{
			return await GetBySourceTableAsync(sourceTable, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SourceTable（字段） 查询
		/// </summary>
		/// /// <param name = "sourceTable">源表名</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceTable(string sourceTable, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(sourceTable != null ? "`SourceTable` = @SourceTable" : "`SourceTable` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (sourceTable != null)
				paras_.Add(Database.CreateInParameter("@SourceTable", sourceTable, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceTableAsync(string sourceTable, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(sourceTable != null ? "`SourceTable` = @SourceTable" : "`SourceTable` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (sourceTable != null)
				paras_.Add(Database.CreateInParameter("@SourceTable", sourceTable, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetBySourceTable
		#region GetBySourceId
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId)
		{
			return GetBySourceId(sourceId, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId)
		{
			return await GetBySourceIdAsync(sourceId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, TransactionManager tm_)
		{
			return GetBySourceId(sourceId, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, TransactionManager tm_)
		{
			return await GetBySourceIdAsync(sourceId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, int top_)
		{
			return GetBySourceId(sourceId, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, int top_)
		{
			return await GetBySourceIdAsync(sourceId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, int top_, TransactionManager tm_)
		{
			return GetBySourceId(sourceId, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, int top_, TransactionManager tm_)
		{
			return await GetBySourceIdAsync(sourceId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, string sort_)
		{
			return GetBySourceId(sourceId, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, string sort_)
		{
			return await GetBySourceIdAsync(sourceId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, string sort_, TransactionManager tm_)
		{
			return GetBySourceId(sourceId, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, string sort_, TransactionManager tm_)
		{
			return await GetBySourceIdAsync(sourceId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 SourceId（字段） 查询
		/// </summary>
		/// /// <param name = "sourceId">源表编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetBySourceId(string sourceId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(sourceId != null ? "`SourceId` = @SourceId" : "`SourceId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (sourceId != null)
				paras_.Add(Database.CreateInParameter("@SourceId", sourceId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetBySourceIdAsync(string sourceId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(sourceId != null ? "`SourceId` = @SourceId" : "`SourceId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (sourceId != null)
				paras_.Add(Database.CreateInParameter("@SourceId", sourceId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetBySourceId
		#region GetByIsBonus
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus)
		{
			return GetByIsBonus(isBonus, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus)
		{
			return await GetByIsBonusAsync(isBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, TransactionManager tm_)
		{
			return GetByIsBonus(isBonus, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, TransactionManager tm_)
		{
			return await GetByIsBonusAsync(isBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, int top_)
		{
			return GetByIsBonus(isBonus, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, int top_)
		{
			return await GetByIsBonusAsync(isBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, int top_, TransactionManager tm_)
		{
			return GetByIsBonus(isBonus, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, int top_, TransactionManager tm_)
		{
			return await GetByIsBonusAsync(isBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, string sort_)
		{
			return GetByIsBonus(isBonus, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, string sort_)
		{
			return await GetByIsBonusAsync(isBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, string sort_, TransactionManager tm_)
		{
			return GetByIsBonus(isBonus, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, string sort_, TransactionManager tm_)
		{
			return await GetByIsBonusAsync(isBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsBonus（字段） 查询
		/// </summary>
		/// /// <param name = "isBonus">是否赠金</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByIsBonus(bool isBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsBonus` = @IsBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByIsBonusAsync(bool isBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsBonus` = @IsBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsBonus", isBonus, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByIsBonus
		#region GetByOrderAmount
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount)
		{
			return GetByOrderAmount(orderAmount, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount)
		{
			return await GetByOrderAmountAsync(orderAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, TransactionManager tm_)
		{
			return GetByOrderAmount(orderAmount, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, TransactionManager tm_)
		{
			return await GetByOrderAmountAsync(orderAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, int top_)
		{
			return GetByOrderAmount(orderAmount, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, int top_)
		{
			return await GetByOrderAmountAsync(orderAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, int top_, TransactionManager tm_)
		{
			return GetByOrderAmount(orderAmount, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, int top_, TransactionManager tm_)
		{
			return await GetByOrderAmountAsync(orderAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, string sort_)
		{
			return GetByOrderAmount(orderAmount, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, string sort_)
		{
			return await GetByOrderAmountAsync(orderAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, string sort_, TransactionManager tm_)
		{
			return GetByOrderAmount(orderAmount, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, string sort_, TransactionManager tm_)
		{
			return await GetByOrderAmountAsync(orderAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderAmount（字段） 查询
		/// </summary>
		/// /// <param name = "orderAmount">当前订单充值或获赠的金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderAmount(long orderAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderAmount` = @OrderAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderAmountAsync(long orderAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderAmount` = @OrderAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderAmount", orderAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByOrderAmount
		#region GetByFlowMultip
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip)
		{
			return GetByFlowMultip(flowMultip, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip)
		{
			return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, TransactionManager tm_)
		{
			return GetByFlowMultip(flowMultip, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, TransactionManager tm_)
		{
			return await GetByFlowMultipAsync(flowMultip, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, int top_)
		{
			return GetByFlowMultip(flowMultip, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, int top_)
		{
			return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, int top_, TransactionManager tm_)
		{
			return GetByFlowMultip(flowMultip, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, int top_, TransactionManager tm_)
		{
			return await GetByFlowMultipAsync(flowMultip, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, string sort_)
		{
			return GetByFlowMultip(flowMultip, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, string sort_)
		{
			return await GetByFlowMultipAsync(flowMultip, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, string sort_, TransactionManager tm_)
		{
			return GetByFlowMultip(flowMultip, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, string sort_, TransactionManager tm_)
		{
			return await GetByFlowMultipAsync(flowMultip, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "flowMultip">要求的流水系数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByFlowMultip(float flowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByFlowMultipAsync(float flowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FlowMultip` = @FlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FlowMultip", flowMultip, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByFlowMultip
		#region GetByRequireFlow
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow)
		{
			return GetByRequireFlow(requireFlow, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow)
		{
			return await GetByRequireFlowAsync(requireFlow, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, TransactionManager tm_)
		{
			return GetByRequireFlow(requireFlow, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, TransactionManager tm_)
		{
			return await GetByRequireFlowAsync(requireFlow, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, int top_)
		{
			return GetByRequireFlow(requireFlow, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, int top_)
		{
			return await GetByRequireFlowAsync(requireFlow, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, int top_, TransactionManager tm_)
		{
			return GetByRequireFlow(requireFlow, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, int top_, TransactionManager tm_)
		{
			return await GetByRequireFlowAsync(requireFlow, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, string sort_)
		{
			return GetByRequireFlow(requireFlow, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, string sort_)
		{
			return await GetByRequireFlowAsync(requireFlow, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, string sort_, TransactionManager tm_)
		{
			return GetByRequireFlow(requireFlow, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, string sort_, TransactionManager tm_)
		{
			return await GetByRequireFlowAsync(requireFlow, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RequireFlow（字段） 查询
		/// </summary>
		/// /// <param name = "requireFlow">提现所要达到的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRequireFlow(long requireFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RequireFlow` = @RequireFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRequireFlowAsync(long requireFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RequireFlow` = @RequireFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RequireFlow", requireFlow, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByRequireFlow
		#region GetByEndBalance
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance)
		{
			return GetByEndBalance(endBalance, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance)
		{
			return await GetByEndBalanceAsync(endBalance, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, TransactionManager tm_)
		{
			return await GetByEndBalanceAsync(endBalance, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, int top_)
		{
			return GetByEndBalance(endBalance, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, int top_)
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
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, int top_, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, int top_, TransactionManager tm_)
		{
			return await GetByEndBalanceAsync(endBalance, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBalance（字段） 查询
		/// </summary>
		/// /// <param name = "endBalance">处理后余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, string sort_)
		{
			return GetByEndBalance(endBalance, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, string sort_)
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
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, string sort_, TransactionManager tm_)
		{
			return GetByEndBalance(endBalance, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByEndBalance(long endBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBalance` = @EndBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBalanceAsync(long endBalance, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBalance` = @EndBalance", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBalance", endBalance, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByEndBalance
		#region GetByEndBonus
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus)
		{
			return GetByEndBonus(endBonus, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus)
		{
			return await GetByEndBonusAsync(endBonus, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, int top_)
		{
			return GetByEndBonus(endBonus, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, int top_)
		{
			return await GetByEndBonusAsync(endBonus, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, int top_, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, int top_, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, string sort_)
		{
			return GetByEndBonus(endBonus, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, string sort_)
		{
			return await GetByEndBonusAsync(endBonus, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, string sort_, TransactionManager tm_)
		{
			return GetByEndBonus(endBonus, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, string sort_, TransactionManager tm_)
		{
			return await GetByEndBonusAsync(endBonus, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 EndBonus（字段） 查询
		/// </summary>
		/// /// <param name = "endBonus">处理后的bonus余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonus(long endBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBonus` = @EndBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusAsync(long endBonus, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`EndBonus` = @EndBonus", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@EndBonus", endBonus, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByEndBonus
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<S_requireflow_orderEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByUpdateTime
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime)
		{
			return GetByUpdateTime(updateTime, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime)
		{
			return await GetByUpdateTimeAsync(updateTime, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, TransactionManager tm_)
		{
			return GetByUpdateTime(updateTime, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, TransactionManager tm_)
		{
			return await GetByUpdateTimeAsync(updateTime, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, int top_)
		{
			return GetByUpdateTime(updateTime, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, int top_)
		{
			return await GetByUpdateTimeAsync(updateTime, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, int top_, TransactionManager tm_)
		{
			return GetByUpdateTime(updateTime, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, int top_, TransactionManager tm_)
		{
			return await GetByUpdateTimeAsync(updateTime, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, string sort_)
		{
			return GetByUpdateTime(updateTime, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, string sort_)
		{
			return await GetByUpdateTimeAsync(updateTime, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, string sort_, TransactionManager tm_)
		{
			return GetByUpdateTime(updateTime, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, string sort_, TransactionManager tm_)
		{
			return await GetByUpdateTimeAsync(updateTime, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UpdateTime（字段） 查询
		/// </summary>
		/// /// <param name = "updateTime">订单修改时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByUpdateTime(DateTime updateTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UpdateTime` = @UpdateTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByUpdateTimeAsync(DateTime updateTime, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`UpdateTime` = @UpdateTime", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@UpdateTime", updateTime, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByUpdateTime
		#region GetByOrderRemain
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain)
		{
			return GetByOrderRemain(orderRemain, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain)
		{
			return await GetByOrderRemainAsync(orderRemain, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, TransactionManager tm_)
		{
			return GetByOrderRemain(orderRemain, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, TransactionManager tm_)
		{
			return await GetByOrderRemainAsync(orderRemain, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, int top_)
		{
			return GetByOrderRemain(orderRemain, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, int top_)
		{
			return await GetByOrderRemainAsync(orderRemain, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, int top_, TransactionManager tm_)
		{
			return GetByOrderRemain(orderRemain, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, int top_, TransactionManager tm_)
		{
			return await GetByOrderRemainAsync(orderRemain, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, string sort_)
		{
			return GetByOrderRemain(orderRemain, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, string sort_)
		{
			return await GetByOrderRemainAsync(orderRemain, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, string sort_, TransactionManager tm_)
		{
			return GetByOrderRemain(orderRemain, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, string sort_, TransactionManager tm_)
		{
			return await GetByOrderRemainAsync(orderRemain, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderRemain（字段） 查询
		/// </summary>
		/// /// <param name = "orderRemain">当前订单剩余金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByOrderRemain(long orderRemain, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderRemain` = @OrderRemain", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByOrderRemainAsync(long orderRemain, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderRemain` = @OrderRemain", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderRemain", orderRemain, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByOrderRemain
		#region GetByInheritOrder
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder)
		{
			return GetByInheritOrder(inheritOrder, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder)
		{
			return await GetByInheritOrderAsync(inheritOrder, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, TransactionManager tm_)
		{
			return GetByInheritOrder(inheritOrder, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, TransactionManager tm_)
		{
			return await GetByInheritOrderAsync(inheritOrder, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, int top_)
		{
			return GetByInheritOrder(inheritOrder, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, int top_)
		{
			return await GetByInheritOrderAsync(inheritOrder, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, int top_, TransactionManager tm_)
		{
			return GetByInheritOrder(inheritOrder, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, int top_, TransactionManager tm_)
		{
			return await GetByInheritOrderAsync(inheritOrder, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, string sort_)
		{
			return GetByInheritOrder(inheritOrder, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, string sort_)
		{
			return await GetByInheritOrderAsync(inheritOrder, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, string sort_, TransactionManager tm_)
		{
			return GetByInheritOrder(inheritOrder, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, string sort_, TransactionManager tm_)
		{
			return await GetByInheritOrderAsync(inheritOrder, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 InheritOrder（字段） 查询
		/// </summary>
		/// /// <param name = "inheritOrder">被继承的余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritOrder(long inheritOrder, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`InheritOrder` = @InheritOrder", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritOrderAsync(long inheritOrder, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`InheritOrder` = @InheritOrder", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritOrder", inheritOrder, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByInheritOrder
		#region GetByCompletedFlow
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow)
		{
			return GetByCompletedFlow(completedFlow, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow)
		{
			return await GetByCompletedFlowAsync(completedFlow, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, TransactionManager tm_)
		{
			return GetByCompletedFlow(completedFlow, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, TransactionManager tm_)
		{
			return await GetByCompletedFlowAsync(completedFlow, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, int top_)
		{
			return GetByCompletedFlow(completedFlow, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, int top_)
		{
			return await GetByCompletedFlowAsync(completedFlow, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, int top_, TransactionManager tm_)
		{
			return GetByCompletedFlow(completedFlow, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, int top_, TransactionManager tm_)
		{
			return await GetByCompletedFlowAsync(completedFlow, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, string sort_)
		{
			return GetByCompletedFlow(completedFlow, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, string sort_)
		{
			return await GetByCompletedFlowAsync(completedFlow, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, string sort_, TransactionManager tm_)
		{
			return GetByCompletedFlow(completedFlow, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, string sort_, TransactionManager tm_)
		{
			return await GetByCompletedFlowAsync(completedFlow, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CompletedFlow（字段） 查询
		/// </summary>
		/// /// <param name = "completedFlow">当前已完成的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByCompletedFlow(long completedFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CompletedFlow` = @CompletedFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByCompletedFlowAsync(long completedFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CompletedFlow` = @CompletedFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CompletedFlow", completedFlow, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByCompletedFlow
		#region GetByInheritFlow
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow)
		{
			return GetByInheritFlow(inheritFlow, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow)
		{
			return await GetByInheritFlowAsync(inheritFlow, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, TransactionManager tm_)
		{
			return GetByInheritFlow(inheritFlow, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, TransactionManager tm_)
		{
			return await GetByInheritFlowAsync(inheritFlow, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, int top_)
		{
			return GetByInheritFlow(inheritFlow, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, int top_)
		{
			return await GetByInheritFlowAsync(inheritFlow, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, int top_, TransactionManager tm_)
		{
			return GetByInheritFlow(inheritFlow, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, int top_, TransactionManager tm_)
		{
			return await GetByInheritFlowAsync(inheritFlow, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, string sort_)
		{
			return GetByInheritFlow(inheritFlow, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, string sort_)
		{
			return await GetByInheritFlowAsync(inheritFlow, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, string sort_, TransactionManager tm_)
		{
			return GetByInheritFlow(inheritFlow, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, string sort_, TransactionManager tm_)
		{
			return await GetByInheritFlowAsync(inheritFlow, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 InheritFlow（字段） 查询
		/// </summary>
		/// /// <param name = "inheritFlow">被继承的流水</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByInheritFlow(long inheritFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`InheritFlow` = @InheritFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByInheritFlowAsync(long inheritFlow, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`InheritFlow` = @InheritFlow", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@InheritFlow", inheritFlow, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByInheritFlow
		#region GetByEndBonusList
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList)
		{
			return GetByEndBonusList(endBonusList, 0, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList)
		{
			return await GetByEndBonusListAsync(endBonusList, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, TransactionManager tm_)
		{
			return GetByEndBonusList(endBonusList, 0, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, TransactionManager tm_)
		{
			return await GetByEndBonusListAsync(endBonusList, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, int top_)
		{
			return GetByEndBonusList(endBonusList, top_, string.Empty, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, int top_)
		{
			return await GetByEndBonusListAsync(endBonusList, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, int top_, TransactionManager tm_)
		{
			return GetByEndBonusList(endBonusList, top_, string.Empty, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, int top_, TransactionManager tm_)
		{
			return await GetByEndBonusListAsync(endBonusList, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, string sort_)
		{
			return GetByEndBonusList(endBonusList, 0, sort_, null);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, string sort_)
		{
			return await GetByEndBonusListAsync(endBonusList, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, string sort_, TransactionManager tm_)
		{
			return GetByEndBonusList(endBonusList, 0, sort_, tm_);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, string sort_, TransactionManager tm_)
		{
			return await GetByEndBonusListAsync(endBonusList, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 EndBonusList（字段） 查询
		/// </summary>
		/// /// <param name = "endBonusList">完成流水后bonus余额列表，|分割</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<S_requireflow_orderEO> GetByEndBonusList(string endBonusList, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(endBonusList != null ? "`EndBonusList` = @EndBonusList" : "`EndBonusList` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (endBonusList != null)
				paras_.Add(Database.CreateInParameter("@EndBonusList", endBonusList, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		public async Task<List<S_requireflow_orderEO>> GetByEndBonusListAsync(string endBonusList, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(endBonusList != null ? "`EndBonusList` = @EndBonusList" : "`EndBonusList` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (endBonusList != null)
				paras_.Add(Database.CreateInParameter("@EndBonusList", endBonusList, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, S_requireflow_orderEO.MapDataReader);
		}
		#endregion // GetByEndBonusList
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
