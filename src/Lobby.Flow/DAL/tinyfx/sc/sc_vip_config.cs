/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-03-20 19: 40:02
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
	/// 用户vip等级配置表
	/// 【表 sc_vip_config 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_vip_configEO : IRowMapper<Sc_vip_configEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_vip_configEO()
		{
			this.PayStartAmount = 0;
			this.PayEndAmount = 0;
			this.GradeFlowMultip = 1.00f;
			this.WeekFlowMultip = 1.00f;
			this.CashRate = 0.00f;
			this.DayCashNumLimit = 0;
			this.DayCashAmountLimit = 0;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private int _originalVipID;
		/// <summary>
		/// 【数据库中的原始主键 VipID 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalVipID
		{
			get { return _originalVipID; }
			set { HasOriginal = true; _originalVipID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "VipID", VipID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 主键
		/// 【主键 int】
		/// </summary>
		[DataMember(Order = 1)]
		public int VipID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 2)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 3)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币编码（现金）
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 4)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// vip等级
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 5)]
		public int VipGrade { get; set; }
		/// <summary>
		/// 需要达到的最小下注额度
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 6)]
		public long BetMinAmount { get; set; }
		/// <summary>
		/// 需要达到的最大下注额度
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long BetMaxAmount { get; set; }
		/// <summary>
		/// 当前vip升级需要的充值金额起始值
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 8)]
		public long PayStartAmount { get; set; }
		/// <summary>
		/// 当前vip升级需要的充值金额截止值
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 9)]
		public long PayEndAmount { get; set; }
		/// <summary>
		/// 升级奖励
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 10)]
		public long GradeReward { get; set; }
		/// <summary>
		/// 升级奖励提现要求的流水倍数
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 11)]
		public float GradeFlowMultip { get; set; }
		/// <summary>
		/// 每周可享收益
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 12)]
		public long WeekReward { get; set; }
		/// <summary>
		/// 每周收益提现要求的流水倍数
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 13)]
		public float WeekFlowMultip { get; set; }
		/// <summary>
		/// 提现手续费
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 14)]
		public float CashRate { get; set; }
		/// <summary>
		/// 每日提现次数上线
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 15)]
		public int DayCashNumLimit { get; set; }
		/// <summary>
		/// 每日提现金额上限
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 16)]
		public long DayCashAmountLimit { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 17)]
		public DateTime RecDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_vip_configEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_vip_configEO MapDataReader(IDataReader reader)
		{
		    Sc_vip_configEO ret = new Sc_vip_configEO();
			ret.VipID = reader.ToInt32("VipID");
			ret.OriginalVipID = ret.VipID;
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.VipGrade = reader.ToInt32("VipGrade");
			ret.BetMinAmount = reader.ToInt64("BetMinAmount");
			ret.BetMaxAmount = reader.ToInt64("BetMaxAmount");
			ret.PayStartAmount = reader.ToInt64("PayStartAmount");
			ret.PayEndAmount = reader.ToInt64("PayEndAmount");
			ret.GradeReward = reader.ToInt64("GradeReward");
			ret.GradeFlowMultip = reader.ToSingle("GradeFlowMultip");
			ret.WeekReward = reader.ToInt64("WeekReward");
			ret.WeekFlowMultip = reader.ToSingle("WeekFlowMultip");
			ret.CashRate = reader.ToSingle("CashRate");
			ret.DayCashNumLimit = reader.ToInt32("DayCashNumLimit");
			ret.DayCashAmountLimit = reader.ToInt64("DayCashAmountLimit");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 用户vip等级配置表
	/// 【表 sc_vip_config 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_vip_configMO : MySqlTableMO<Sc_vip_configEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_vip_config`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_vip_configMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_vip_configMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_vip_configMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_vip_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			item.VipID = Database.ExecSqlScalar<int>(sql_, paras_, tm_); 
			return 1;
		}
		public override async Task<int> AddAsync(Sc_vip_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			item.VipID = await Database.ExecSqlScalarAsync<int>(sql_, paras_, tm_); 
	        return 1;
		}
	    private void RepairAddData(Sc_vip_configEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperatorID`, `CountryID`, `CurrencyID`, `VipGrade`, `BetMinAmount`, `BetMaxAmount`, `PayStartAmount`, `PayEndAmount`, `GradeReward`, `GradeFlowMultip`, `WeekReward`, `WeekFlowMultip`, `CashRate`, `DayCashNumLimit`, `DayCashAmountLimit`, `RecDate`) VALUE (@OperatorID, @CountryID, @CurrencyID, @VipGrade, @BetMinAmount, @BetMaxAmount, @PayStartAmount, @PayEndAmount, @GradeReward, @GradeFlowMultip, @WeekReward, @WeekFlowMultip, @CashRate, @DayCashNumLimit, @DayCashAmountLimit, @RecDate);SELECT LAST_INSERT_ID();";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VipGrade", item.VipGrade, MySqlDbType.Int32),
				Database.CreateInParameter("@BetMinAmount", item.BetMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BetMaxAmount", item.BetMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayStartAmount", item.PayStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayEndAmount", item.PayEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@GradeReward", item.GradeReward, MySqlDbType.Int64),
				Database.CreateInParameter("@GradeFlowMultip", item.GradeFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@WeekReward", item.WeekReward, MySqlDbType.Int64),
				Database.CreateInParameter("@WeekFlowMultip", item.WeekFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@CashRate", item.CashRate, MySqlDbType.Float),
				Database.CreateInParameter("@DayCashNumLimit", item.DayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@DayCashAmountLimit", item.DayCashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sc_vip_configEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_vip_configEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_vip_configEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`VipID`, `OperatorID`, `CountryID`, `CurrencyID`, `VipGrade`, `BetMinAmount`, `BetMaxAmount`, `PayStartAmount`, `PayEndAmount`, `GradeReward`, `GradeFlowMultip`, `WeekReward`, `WeekFlowMultip`, `CashRate`, `DayCashNumLimit`, `DayCashAmountLimit`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"({item.VipID},'{item.OperatorID}','{item.CountryID}','{item.CurrencyID}',{item.VipGrade},{item.BetMinAmount},{item.BetMaxAmount},{item.PayStartAmount},{item.PayEndAmount},{item.GradeReward},{item.GradeFlowMultip},{item.WeekReward},{item.WeekFlowMultip},{item.CashRate},{item.DayCashNumLimit},{item.DayCashAmountLimit},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(int vipID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(vipID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(vipID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(int vipID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_vip_configEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.VipID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_vip_configEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.VipID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
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
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>();
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
			sql_ = $"DELETE FROM {TableName} WHERE `CountryID` = @CountryID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCountryID
		#region RemoveByCurrencyID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
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
			sql_ = $"DELETE FROM {TableName} WHERE `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCurrencyID
		#region RemoveByVipGrade
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByVipGrade(int vipGrade, TransactionManager tm_ = null)
		{
			RepairRemoveByVipGradeData(vipGrade, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByVipGradeAsync(int vipGrade, TransactionManager tm_ = null)
		{
			RepairRemoveByVipGradeData(vipGrade, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByVipGradeData(int vipGrade, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `VipGrade` = @VipGrade";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32));
		}
		#endregion // RemoveByVipGrade
		#region RemoveByBetMinAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBetMinAmount(long betMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetMinAmountData(betMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBetMinAmountAsync(long betMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetMinAmountData(betMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBetMinAmountData(long betMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BetMinAmount` = @BetMinAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBetMinAmount
		#region RemoveByBetMaxAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBetMaxAmount(long betMaxAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetMaxAmountData(betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetMaxAmountData(betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBetMaxAmountData(long betMaxAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BetMaxAmount` = @BetMaxAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBetMaxAmount
		#region RemoveByPayStartAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayStartAmount(long payStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayStartAmountData(payStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayStartAmountAsync(long payStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayStartAmountData(payStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayStartAmountData(long payStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayStartAmount` = @PayStartAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByPayStartAmount
		#region RemoveByPayEndAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayEndAmount(long payEndAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayEndAmountData(payEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayEndAmountAsync(long payEndAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByPayEndAmountData(payEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayEndAmountData(long payEndAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayEndAmount` = @PayEndAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByPayEndAmount
		#region RemoveByGradeReward
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGradeReward(long gradeReward, TransactionManager tm_ = null)
		{
			RepairRemoveByGradeRewardData(gradeReward, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByGradeRewardAsync(long gradeReward, TransactionManager tm_ = null)
		{
			RepairRemoveByGradeRewardData(gradeReward, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByGradeRewardData(long gradeReward, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `GradeReward` = @GradeReward";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64));
		}
		#endregion // RemoveByGradeReward
		#region RemoveByGradeFlowMultip
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGradeFlowMultip(float gradeFlowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByGradeFlowMultipData(gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByGradeFlowMultipAsync(float gradeFlowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByGradeFlowMultipData(gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByGradeFlowMultipData(float gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `GradeFlowMultip` = @GradeFlowMultip";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float));
		}
		#endregion // RemoveByGradeFlowMultip
		#region RemoveByWeekReward
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByWeekReward(long weekReward, TransactionManager tm_ = null)
		{
			RepairRemoveByWeekRewardData(weekReward, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByWeekRewardAsync(long weekReward, TransactionManager tm_ = null)
		{
			RepairRemoveByWeekRewardData(weekReward, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByWeekRewardData(long weekReward, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `WeekReward` = @WeekReward";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64));
		}
		#endregion // RemoveByWeekReward
		#region RemoveByWeekFlowMultip
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByWeekFlowMultip(float weekFlowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByWeekFlowMultipData(weekFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByWeekFlowMultipAsync(float weekFlowMultip, TransactionManager tm_ = null)
		{
			RepairRemoveByWeekFlowMultipData(weekFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByWeekFlowMultipData(float weekFlowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `WeekFlowMultip` = @WeekFlowMultip";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float));
		}
		#endregion // RemoveByWeekFlowMultip
		#region RemoveByCashRate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
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
		#region RemoveByDayCashNumLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashNumLimitData(dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashNumLimitData(dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByDayCashNumLimitData(int dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `DayCashNumLimit` = @DayCashNumLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
		}
		#endregion // RemoveByDayCashNumLimit
		#region RemoveByDayCashAmountLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDayCashAmountLimit(long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashAmountLimitData(dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByDayCashAmountLimitAsync(long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashAmountLimitData(dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByDayCashAmountLimitData(long dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `DayCashAmountLimit` = @DayCashAmountLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByDayCashAmountLimit
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
		public int Put(Sc_vip_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_vip_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_vip_configEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `VipGrade` = @VipGrade, `BetMinAmount` = @BetMinAmount, `BetMaxAmount` = @BetMaxAmount, `PayStartAmount` = @PayStartAmount, `PayEndAmount` = @PayEndAmount, `GradeReward` = @GradeReward, `GradeFlowMultip` = @GradeFlowMultip, `WeekReward` = @WeekReward, `WeekFlowMultip` = @WeekFlowMultip, `CashRate` = @CashRate, `DayCashNumLimit` = @DayCashNumLimit, `DayCashAmountLimit` = @DayCashAmountLimit WHERE `VipID` = @VipID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VipGrade", item.VipGrade, MySqlDbType.Int32),
				Database.CreateInParameter("@BetMinAmount", item.BetMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BetMaxAmount", item.BetMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayStartAmount", item.PayStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@PayEndAmount", item.PayEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@GradeReward", item.GradeReward, MySqlDbType.Int64),
				Database.CreateInParameter("@GradeFlowMultip", item.GradeFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@WeekReward", item.WeekReward, MySqlDbType.Int64),
				Database.CreateInParameter("@WeekFlowMultip", item.WeekFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@CashRate", item.CashRate, MySqlDbType.Float),
				Database.CreateInParameter("@DayCashNumLimit", item.DayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@DayCashAmountLimit", item.DayCashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID_Original", item.HasOriginal ? item.OriginalVipID : item.VipID, MySqlDbType.Int32),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_vip_configEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_vip_configEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "vipID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int vipID, string set_, params object[] values_)
		{
			return Put(set_, "`VipID` = @VipID", ConcatValues(values_, vipID));
		}
		public async Task<int> PutByPKAsync(int vipID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`VipID` = @VipID", ConcatValues(values_, vipID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int vipID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`VipID` = @VipID", tm_, ConcatValues(values_, vipID));
		}
		public async Task<int> PutByPKAsync(int vipID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`VipID` = @VipID", tm_, ConcatValues(values_, vipID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int vipID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
	        };
			return Put(set_, "`VipID` = @VipID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(int vipID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
	        };
			return await PutAsync(set_, "`VipID` = @VipID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(int vipID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(vipID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(int vipID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(vipID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(int vipID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
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
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorID
		#region PutCountryID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(int vipID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(vipID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(int vipID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(vipID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(int vipID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
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
			var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCountryID
		#region PutCurrencyID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(int vipID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(vipID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(int vipID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(vipID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(int vipID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrencyID
		#region PutVipGrade
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVipGradeByPK(int vipID, int vipGrade, TransactionManager tm_ = null)
		{
			RepairPutVipGradeByPKData(vipID, vipGrade, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutVipGradeByPKAsync(int vipID, int vipGrade, TransactionManager tm_ = null)
		{
			RepairPutVipGradeByPKData(vipID, vipGrade, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutVipGradeByPKData(int vipID, int vipGrade, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `VipGrade` = @VipGrade  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVipGrade(int vipGrade, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VipGrade` = @VipGrade";
			var parameter_ = Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutVipGradeAsync(int vipGrade, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VipGrade` = @VipGrade";
			var parameter_ = Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutVipGrade
		#region PutBetMinAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetMinAmountByPK(int vipID, long betMinAmount, TransactionManager tm_ = null)
		{
			RepairPutBetMinAmountByPKData(vipID, betMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBetMinAmountByPKAsync(int vipID, long betMinAmount, TransactionManager tm_ = null)
		{
			RepairPutBetMinAmountByPKData(vipID, betMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBetMinAmountByPKData(int vipID, long betMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetMinAmount(long betMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount";
			var parameter_ = Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBetMinAmountAsync(long betMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetMinAmount` = @BetMinAmount";
			var parameter_ = Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBetMinAmount
		#region PutBetMaxAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetMaxAmountByPK(int vipID, long betMaxAmount, TransactionManager tm_ = null)
		{
			RepairPutBetMaxAmountByPKData(vipID, betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBetMaxAmountByPKAsync(int vipID, long betMaxAmount, TransactionManager tm_ = null)
		{
			RepairPutBetMaxAmountByPKData(vipID, betMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBetMaxAmountByPKData(int vipID, long betMaxAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetMaxAmount(long betMaxAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount";
			var parameter_ = Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetMaxAmount` = @BetMaxAmount";
			var parameter_ = Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBetMaxAmount
		#region PutPayStartAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayStartAmountByPK(int vipID, long payStartAmount, TransactionManager tm_ = null)
		{
			RepairPutPayStartAmountByPKData(vipID, payStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayStartAmountByPKAsync(int vipID, long payStartAmount, TransactionManager tm_ = null)
		{
			RepairPutPayStartAmountByPKData(vipID, payStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayStartAmountByPKData(int vipID, long payStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayStartAmount` = @PayStartAmount  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayStartAmount(long payStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayStartAmount` = @PayStartAmount";
			var parameter_ = Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayStartAmountAsync(long payStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayStartAmount` = @PayStartAmount";
			var parameter_ = Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayStartAmount
		#region PutPayEndAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayEndAmountByPK(int vipID, long payEndAmount, TransactionManager tm_ = null)
		{
			RepairPutPayEndAmountByPKData(vipID, payEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayEndAmountByPKAsync(int vipID, long payEndAmount, TransactionManager tm_ = null)
		{
			RepairPutPayEndAmountByPKData(vipID, payEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayEndAmountByPKData(int vipID, long payEndAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayEndAmount` = @PayEndAmount  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayEndAmount(long payEndAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayEndAmount` = @PayEndAmount";
			var parameter_ = Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayEndAmountAsync(long payEndAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayEndAmount` = @PayEndAmount";
			var parameter_ = Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayEndAmount
		#region PutGradeReward
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGradeRewardByPK(int vipID, long gradeReward, TransactionManager tm_ = null)
		{
			RepairPutGradeRewardByPKData(vipID, gradeReward, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutGradeRewardByPKAsync(int vipID, long gradeReward, TransactionManager tm_ = null)
		{
			RepairPutGradeRewardByPKData(vipID, gradeReward, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutGradeRewardByPKData(int vipID, long gradeReward, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `GradeReward` = @GradeReward  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGradeReward(long gradeReward, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GradeReward` = @GradeReward";
			var parameter_ = Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutGradeRewardAsync(long gradeReward, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GradeReward` = @GradeReward";
			var parameter_ = Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGradeReward
		#region PutGradeFlowMultip
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGradeFlowMultipByPK(int vipID, float gradeFlowMultip, TransactionManager tm_ = null)
		{
			RepairPutGradeFlowMultipByPKData(vipID, gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutGradeFlowMultipByPKAsync(int vipID, float gradeFlowMultip, TransactionManager tm_ = null)
		{
			RepairPutGradeFlowMultipByPKData(vipID, gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutGradeFlowMultipByPKData(int vipID, float gradeFlowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `GradeFlowMultip` = @GradeFlowMultip  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGradeFlowMultip(float gradeFlowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GradeFlowMultip` = @GradeFlowMultip";
			var parameter_ = Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutGradeFlowMultipAsync(float gradeFlowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GradeFlowMultip` = @GradeFlowMultip";
			var parameter_ = Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGradeFlowMultip
		#region PutWeekReward
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWeekRewardByPK(int vipID, long weekReward, TransactionManager tm_ = null)
		{
			RepairPutWeekRewardByPKData(vipID, weekReward, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutWeekRewardByPKAsync(int vipID, long weekReward, TransactionManager tm_ = null)
		{
			RepairPutWeekRewardByPKData(vipID, weekReward, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutWeekRewardByPKData(int vipID, long weekReward, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `WeekReward` = @WeekReward  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWeekReward(long weekReward, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WeekReward` = @WeekReward";
			var parameter_ = Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutWeekRewardAsync(long weekReward, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WeekReward` = @WeekReward";
			var parameter_ = Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutWeekReward
		#region PutWeekFlowMultip
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWeekFlowMultipByPK(int vipID, float weekFlowMultip, TransactionManager tm_ = null)
		{
			RepairPutWeekFlowMultipByPKData(vipID, weekFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutWeekFlowMultipByPKAsync(int vipID, float weekFlowMultip, TransactionManager tm_ = null)
		{
			RepairPutWeekFlowMultipByPKData(vipID, weekFlowMultip, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutWeekFlowMultipByPKData(int vipID, float weekFlowMultip, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `WeekFlowMultip` = @WeekFlowMultip  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWeekFlowMultip(float weekFlowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WeekFlowMultip` = @WeekFlowMultip";
			var parameter_ = Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutWeekFlowMultipAsync(float weekFlowMultip, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WeekFlowMultip` = @WeekFlowMultip";
			var parameter_ = Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutWeekFlowMultip
		#region PutCashRate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashRateByPK(int vipID, float cashRate, TransactionManager tm_ = null)
		{
			RepairPutCashRateByPKData(vipID, cashRate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashRateByPKAsync(int vipID, float cashRate, TransactionManager tm_ = null)
		{
			RepairPutCashRateByPKData(vipID, cashRate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashRateByPKData(int vipID, float cashRate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashRate` = @CashRate  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
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
		#region PutDayCashNumLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashNumLimitByPK(int vipID, int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashNumLimitByPKData(vipID, dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutDayCashNumLimitByPKAsync(int vipID, int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashNumLimitByPKData(vipID, dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutDayCashNumLimitByPKData(int vipID, int dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit";
			var parameter_ = Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit";
			var parameter_ = Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDayCashNumLimit
		#region PutDayCashAmountLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashAmountLimitByPK(int vipID, long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashAmountLimitByPKData(vipID, dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutDayCashAmountLimitByPKAsync(int vipID, long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashAmountLimitByPKData(vipID, dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutDayCashAmountLimitByPKData(int vipID, long dayCashAmountLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DayCashAmountLimit` = @DayCashAmountLimit  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashAmountLimit(long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashAmountLimit` = @DayCashAmountLimit";
			var parameter_ = Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutDayCashAmountLimitAsync(long dayCashAmountLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashAmountLimit` = @DayCashAmountLimit";
			var parameter_ = Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDayCashAmountLimit
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(int vipID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(vipID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(int vipID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(vipID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(int vipID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `VipID` = @VipID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_vip_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.VipID) == null)
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
		public async Task<bool> SetAsync(Sc_vip_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.VipID) == null)
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
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_vip_configEO GetByPK(int vipID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(vipID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<Sc_vip_configEO> GetByPKAsync(int vipID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(vipID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		private void RepairGetByPKData(int vipID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`VipID` = @VipID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`OperatorID`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`CountryID`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`CountryID`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`CurrencyID`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 VipGrade（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetVipGradeByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`VipGrade`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<int> GetVipGradeByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`VipGrade`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BetMinAmount（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBetMinAmountByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`BetMinAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetBetMinAmountByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`BetMinAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BetMaxAmount（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBetMaxAmountByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`BetMaxAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetBetMaxAmountByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`BetMaxAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayStartAmount（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPayStartAmountByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`PayStartAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetPayStartAmountByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`PayStartAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayEndAmount（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetPayEndAmountByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`PayEndAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetPayEndAmountByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`PayEndAmount`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 GradeReward（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetGradeRewardByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`GradeReward`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetGradeRewardByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`GradeReward`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 GradeFlowMultip（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetGradeFlowMultipByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`GradeFlowMultip`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<float> GetGradeFlowMultipByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`GradeFlowMultip`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 WeekReward（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetWeekRewardByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`WeekReward`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetWeekRewardByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`WeekReward`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 WeekFlowMultip（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetWeekFlowMultipByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`WeekFlowMultip`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<float> GetWeekFlowMultipByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`WeekFlowMultip`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashRate（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetCashRateByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`CashRate`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<float> GetCashRateByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`CashRate`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 DayCashNumLimit（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetDayCashNumLimitByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`DayCashNumLimit`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<int> GetDayCashNumLimitByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`DayCashNumLimit`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 DayCashAmountLimit（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetDayCashAmountLimitByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`DayCashAmountLimit`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<long> GetDayCashAmountLimitByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`DayCashAmountLimit`", "`VipID` = @VipID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "vipID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (DateTime)GetScalar("`RecDate`", "`VipID` = @VipID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(int vipID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VipID", vipID, MySqlDbType.Int32),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`VipID` = @VipID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_vip_configEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<Sc_vip_configEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<Sc_vip_configEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<Sc_vip_configEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码（现金）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByVipGrade
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade)
		{
			return GetByVipGrade(vipGrade, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade)
		{
			return await GetByVipGradeAsync(vipGrade, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, TransactionManager tm_)
		{
			return GetByVipGrade(vipGrade, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, TransactionManager tm_)
		{
			return await GetByVipGradeAsync(vipGrade, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, int top_)
		{
			return GetByVipGrade(vipGrade, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, int top_)
		{
			return await GetByVipGradeAsync(vipGrade, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, int top_, TransactionManager tm_)
		{
			return GetByVipGrade(vipGrade, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, int top_, TransactionManager tm_)
		{
			return await GetByVipGradeAsync(vipGrade, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, string sort_)
		{
			return GetByVipGrade(vipGrade, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, string sort_)
		{
			return await GetByVipGradeAsync(vipGrade, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, string sort_, TransactionManager tm_)
		{
			return GetByVipGrade(vipGrade, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, string sort_, TransactionManager tm_)
		{
			return await GetByVipGradeAsync(vipGrade, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 VipGrade（字段） 查询
		/// </summary>
		/// /// <param name = "vipGrade">vip等级</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByVipGrade(int vipGrade, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`VipGrade` = @VipGrade", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByVipGradeAsync(int vipGrade, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`VipGrade` = @VipGrade", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VipGrade", vipGrade, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByVipGrade
		#region GetByBetMinAmount
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount)
		{
			return GetByBetMinAmount(betMinAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount)
		{
			return await GetByBetMinAmountAsync(betMinAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, TransactionManager tm_)
		{
			return GetByBetMinAmount(betMinAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, TransactionManager tm_)
		{
			return await GetByBetMinAmountAsync(betMinAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, int top_)
		{
			return GetByBetMinAmount(betMinAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_)
		{
			return await GetByBetMinAmountAsync(betMinAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, int top_, TransactionManager tm_)
		{
			return GetByBetMinAmount(betMinAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_, TransactionManager tm_)
		{
			return await GetByBetMinAmountAsync(betMinAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, string sort_)
		{
			return GetByBetMinAmount(betMinAmount, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, string sort_)
		{
			return await GetByBetMinAmountAsync(betMinAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, string sort_, TransactionManager tm_)
		{
			return GetByBetMinAmount(betMinAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBetMinAmountAsync(betMinAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BetMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMinAmount">需要达到的最小下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMinAmount(long betMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetMinAmount` = @BetMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMinAmountAsync(long betMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetMinAmount` = @BetMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMinAmount", betMinAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByBetMinAmount
		#region GetByBetMaxAmount
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount)
		{
			return GetByBetMaxAmount(betMaxAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, TransactionManager tm_)
		{
			return GetByBetMaxAmount(betMaxAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, TransactionManager tm_)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, int top_)
		{
			return GetByBetMaxAmount(betMaxAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, int top_, TransactionManager tm_)
		{
			return GetByBetMaxAmount(betMaxAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_, TransactionManager tm_)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, string sort_)
		{
			return GetByBetMaxAmount(betMaxAmount, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, string sort_)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, string sort_, TransactionManager tm_)
		{
			return GetByBetMaxAmount(betMaxAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBetMaxAmountAsync(betMaxAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BetMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betMaxAmount">需要达到的最大下注额度</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByBetMaxAmount(long betMaxAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetMaxAmount` = @BetMaxAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByBetMaxAmountAsync(long betMaxAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetMaxAmount` = @BetMaxAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetMaxAmount", betMaxAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByBetMaxAmount
		#region GetByPayStartAmount
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount)
		{
			return GetByPayStartAmount(payStartAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount)
		{
			return await GetByPayStartAmountAsync(payStartAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, TransactionManager tm_)
		{
			return GetByPayStartAmount(payStartAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, TransactionManager tm_)
		{
			return await GetByPayStartAmountAsync(payStartAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, int top_)
		{
			return GetByPayStartAmount(payStartAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, int top_)
		{
			return await GetByPayStartAmountAsync(payStartAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, int top_, TransactionManager tm_)
		{
			return GetByPayStartAmount(payStartAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, int top_, TransactionManager tm_)
		{
			return await GetByPayStartAmountAsync(payStartAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, string sort_)
		{
			return GetByPayStartAmount(payStartAmount, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, string sort_)
		{
			return await GetByPayStartAmountAsync(payStartAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, string sort_, TransactionManager tm_)
		{
			return GetByPayStartAmount(payStartAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPayStartAmountAsync(payStartAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payStartAmount">当前vip升级需要的充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayStartAmount(long payStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayStartAmount` = @PayStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayStartAmountAsync(long payStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayStartAmount` = @PayStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayStartAmount", payStartAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByPayStartAmount
		#region GetByPayEndAmount
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount)
		{
			return GetByPayEndAmount(payEndAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount)
		{
			return await GetByPayEndAmountAsync(payEndAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, TransactionManager tm_)
		{
			return GetByPayEndAmount(payEndAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, TransactionManager tm_)
		{
			return await GetByPayEndAmountAsync(payEndAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, int top_)
		{
			return GetByPayEndAmount(payEndAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, int top_)
		{
			return await GetByPayEndAmountAsync(payEndAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, int top_, TransactionManager tm_)
		{
			return GetByPayEndAmount(payEndAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, int top_, TransactionManager tm_)
		{
			return await GetByPayEndAmountAsync(payEndAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, string sort_)
		{
			return GetByPayEndAmount(payEndAmount, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, string sort_)
		{
			return await GetByPayEndAmountAsync(payEndAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, string sort_, TransactionManager tm_)
		{
			return GetByPayEndAmount(payEndAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, string sort_, TransactionManager tm_)
		{
			return await GetByPayEndAmountAsync(payEndAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "payEndAmount">当前vip升级需要的充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByPayEndAmount(long payEndAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayEndAmount` = @PayEndAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByPayEndAmountAsync(long payEndAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayEndAmount` = @PayEndAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayEndAmount", payEndAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByPayEndAmount
		#region GetByGradeReward
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward)
		{
			return GetByGradeReward(gradeReward, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward)
		{
			return await GetByGradeRewardAsync(gradeReward, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, TransactionManager tm_)
		{
			return GetByGradeReward(gradeReward, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, TransactionManager tm_)
		{
			return await GetByGradeRewardAsync(gradeReward, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, int top_)
		{
			return GetByGradeReward(gradeReward, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, int top_)
		{
			return await GetByGradeRewardAsync(gradeReward, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, int top_, TransactionManager tm_)
		{
			return GetByGradeReward(gradeReward, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, int top_, TransactionManager tm_)
		{
			return await GetByGradeRewardAsync(gradeReward, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, string sort_)
		{
			return GetByGradeReward(gradeReward, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, string sort_)
		{
			return await GetByGradeRewardAsync(gradeReward, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, string sort_, TransactionManager tm_)
		{
			return GetByGradeReward(gradeReward, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, string sort_, TransactionManager tm_)
		{
			return await GetByGradeRewardAsync(gradeReward, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GradeReward（字段） 查询
		/// </summary>
		/// /// <param name = "gradeReward">升级奖励</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeReward(long gradeReward, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GradeReward` = @GradeReward", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeRewardAsync(long gradeReward, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GradeReward` = @GradeReward", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeReward", gradeReward, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByGradeReward
		#region GetByGradeFlowMultip
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, TransactionManager tm_)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, TransactionManager tm_)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, int top_)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, int top_)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, int top_, TransactionManager tm_)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, int top_, TransactionManager tm_)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, string sort_)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, string sort_)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, string sort_, TransactionManager tm_)
		{
			return GetByGradeFlowMultip(gradeFlowMultip, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, string sort_, TransactionManager tm_)
		{
			return await GetByGradeFlowMultipAsync(gradeFlowMultip, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GradeFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "gradeFlowMultip">升级奖励提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByGradeFlowMultip(float gradeFlowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GradeFlowMultip` = @GradeFlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByGradeFlowMultipAsync(float gradeFlowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GradeFlowMultip` = @GradeFlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GradeFlowMultip", gradeFlowMultip, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByGradeFlowMultip
		#region GetByWeekReward
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward)
		{
			return GetByWeekReward(weekReward, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward)
		{
			return await GetByWeekRewardAsync(weekReward, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, TransactionManager tm_)
		{
			return GetByWeekReward(weekReward, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, TransactionManager tm_)
		{
			return await GetByWeekRewardAsync(weekReward, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, int top_)
		{
			return GetByWeekReward(weekReward, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, int top_)
		{
			return await GetByWeekRewardAsync(weekReward, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, int top_, TransactionManager tm_)
		{
			return GetByWeekReward(weekReward, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, int top_, TransactionManager tm_)
		{
			return await GetByWeekRewardAsync(weekReward, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, string sort_)
		{
			return GetByWeekReward(weekReward, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, string sort_)
		{
			return await GetByWeekRewardAsync(weekReward, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, string sort_, TransactionManager tm_)
		{
			return GetByWeekReward(weekReward, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, string sort_, TransactionManager tm_)
		{
			return await GetByWeekRewardAsync(weekReward, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 WeekReward（字段） 查询
		/// </summary>
		/// /// <param name = "weekReward">每周可享收益</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekReward(long weekReward, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WeekReward` = @WeekReward", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekRewardAsync(long weekReward, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WeekReward` = @WeekReward", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekReward", weekReward, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByWeekReward
		#region GetByWeekFlowMultip
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip)
		{
			return GetByWeekFlowMultip(weekFlowMultip, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, TransactionManager tm_)
		{
			return GetByWeekFlowMultip(weekFlowMultip, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, TransactionManager tm_)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, int top_)
		{
			return GetByWeekFlowMultip(weekFlowMultip, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, int top_)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, int top_, TransactionManager tm_)
		{
			return GetByWeekFlowMultip(weekFlowMultip, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, int top_, TransactionManager tm_)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, string sort_)
		{
			return GetByWeekFlowMultip(weekFlowMultip, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, string sort_)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, string sort_, TransactionManager tm_)
		{
			return GetByWeekFlowMultip(weekFlowMultip, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, string sort_, TransactionManager tm_)
		{
			return await GetByWeekFlowMultipAsync(weekFlowMultip, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 WeekFlowMultip（字段） 查询
		/// </summary>
		/// /// <param name = "weekFlowMultip">每周收益提现要求的流水倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByWeekFlowMultip(float weekFlowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WeekFlowMultip` = @WeekFlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByWeekFlowMultipAsync(float weekFlowMultip, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WeekFlowMultip` = @WeekFlowMultip", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WeekFlowMultip", weekFlowMultip, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByWeekFlowMultip
		#region GetByCashRate
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate)
		{
			return GetByCashRate(cashRate, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate)
		{
			return await GetByCashRateAsync(cashRate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, int top_)
		{
			return GetByCashRate(cashRate, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, int top_)
		{
			return await GetByCashRateAsync(cashRate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, int top_, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, int top_, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, string sort_)
		{
			return GetByCashRate(cashRate, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, string sort_)
		{
			return await GetByCashRateAsync(cashRate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, string sort_, TransactionManager tm_)
		{
			return GetByCashRate(cashRate, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, string sort_, TransactionManager tm_)
		{
			return await GetByCashRateAsync(cashRate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashRate（字段） 查询
		/// </summary>
		/// /// <param name = "cashRate">提现手续费</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByCashRate(float cashRate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashRate` = @CashRate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByCashRateAsync(float cashRate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashRate` = @CashRate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashRate", cashRate, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByCashRate
		#region GetByDayCashNumLimit
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, string sort_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, string sort_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, string sort_, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, string sort_, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">每日提现次数上线</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashNumLimit` = @DayCashNumLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashNumLimit` = @DayCashNumLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByDayCashNumLimit
		#region GetByDayCashAmountLimit
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, TransactionManager tm_)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, TransactionManager tm_)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, int top_)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, int top_)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, int top_, TransactionManager tm_)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, int top_, TransactionManager tm_)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, string sort_)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, string sort_)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, string sort_, TransactionManager tm_)
		{
			return GetByDayCashAmountLimit(dayCashAmountLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, string sort_, TransactionManager tm_)
		{
			return await GetByDayCashAmountLimitAsync(dayCashAmountLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DayCashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashAmountLimit">每日提现金额上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByDayCashAmountLimit(long dayCashAmountLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashAmountLimit` = @DayCashAmountLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByDayCashAmountLimitAsync(long dayCashAmountLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashAmountLimit` = @DayCashAmountLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashAmountLimit", dayCashAmountLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByDayCashAmountLimit
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sc_vip_configEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		public async Task<List<Sc_vip_configEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_vip_configEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
