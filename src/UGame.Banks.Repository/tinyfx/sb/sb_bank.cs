/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-12-08 17: 15:29
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
	/// 银行表
	/// 【表 sb_bank 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_bankEO : IRowMapper<Sb_bankEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_bankEO()
		{
			this.BankType = 0;
			this.PayFee = 0.000000m;
			this.CashFee = 0.000000m;
			this.Status = 0;
			this.VerifyDelay = 100;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalBankID;
		/// <summary>
		/// 【数据库中的原始主键 BankID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalBankID
		{
			get { return _originalBankID; }
			set { HasOriginal = true; _originalBankID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "BankID", BankID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 银行编码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string BankID { get; set; }
		/// <summary>
		/// 银行名称
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 2)]
		public string BankName { get; set; }
		/// <summary>
		/// 银行类型
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 3)]
		public int BankType { get; set; }
		/// <summary>
		/// 第三方公钥
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 4)]
		public string TrdPublicKey { get; set; }
		/// <summary>
		/// 我方的公钥
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 5)]
		public string OwnPublicKey { get; set; }
		/// <summary>
		/// 我方的私钥
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 6)]
		public string OwnPrivateKey { get; set; }
		/// <summary>
		/// 充值费率
		/// 0 - 无费率
		/// -1  不通过该方式计算费率
		/// 0.03等
		/// 【字段 decimal(9,6)】
		/// </summary>
		[DataMember(Order = 7)]
		public decimal PayFee { get; set; }
		/// <summary>
		/// 提现费率
		/// 0 - 无费率
		/// -1  不通过该方式计算费率
		/// 0.03等
		/// 【字段 decimal(9,6)】
		/// </summary>
		[DataMember(Order = 8)]
		public decimal CashFee { get; set; }
		/// <summary>
		/// 备注信息
		/// 【字段 varchar(1000)】
		/// </summary>
		[DataMember(Order = 9)]
		public string Note { get; set; }
		/// <summary>
		/// 状态(0-无效1-有效)
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 10)]
		public int Status { get; set; }
		/// <summary>
		/// 验证三方订单调用延时（单位毫秒）
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 11)]
		public int VerifyDelay { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 12)]
		public DateTime RecDate { get; set; }
		/// <summary>
		/// bank配置参数
		/// 【字段 text】
		/// </summary>
		[DataMember(Order = 13)]
		public string BankConfig { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_bankEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_bankEO MapDataReader(IDataReader reader)
		{
		    Sb_bankEO ret = new Sb_bankEO();
			ret.BankID = reader.ToString("BankID");
			ret.OriginalBankID = ret.BankID;
			ret.BankName = reader.ToString("BankName");
			ret.BankType = reader.ToInt32("BankType");
			ret.TrdPublicKey = reader.ToString("TrdPublicKey");
			ret.OwnPublicKey = reader.ToString("OwnPublicKey");
			ret.OwnPrivateKey = reader.ToString("OwnPrivateKey");
			ret.PayFee = reader.ToDecimal("PayFee");
			ret.CashFee = reader.ToDecimal("CashFee");
			ret.Note = reader.ToString("Note");
			ret.Status = reader.ToInt32("Status");
			ret.VerifyDelay = reader.ToInt32("VerifyDelay");
			ret.RecDate = reader.ToDateTime("RecDate");
			ret.BankConfig = reader.ToString("BankConfig");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 银行表
	/// 【表 sb_bank 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_bankMO : MySqlTableMO<Sb_bankEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_bank`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_bankMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_bankMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_bankMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_bankEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_bankEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_bankEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`BankID`, `BankName`, `BankType`, `TrdPublicKey`, `OwnPublicKey`, `OwnPrivateKey`, `PayFee`, `CashFee`, `Note`, `Status`, `VerifyDelay`, `RecDate`, `BankConfig`) VALUE (@BankID, @BankName, @BankType, @TrdPublicKey, @OwnPublicKey, @OwnPrivateKey, @PayFee, @CashFee, @Note, @Status, @VerifyDelay, @RecDate, @BankConfig);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", item.BankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankType", item.BankType, MySqlDbType.Int32),
				Database.CreateInParameter("@TrdPublicKey", item.TrdPublicKey != null ? item.TrdPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OwnPublicKey", item.OwnPublicKey != null ? item.OwnPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OwnPrivateKey", item.OwnPrivateKey != null ? item.OwnPrivateKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@PayFee", item.PayFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@CashFee", item.CashFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@VerifyDelay", item.VerifyDelay, MySqlDbType.Int32),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankConfig", item.BankConfig != null ? item.BankConfig : (object)DBNull.Value, MySqlDbType.Text),
			};
		}
		public int AddByBatch(IEnumerable<Sb_bankEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_bankEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_bankEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`BankID`, `BankName`, `BankType`, `TrdPublicKey`, `OwnPublicKey`, `OwnPrivateKey`, `PayFee`, `CashFee`, `Note`, `Status`, `VerifyDelay`, `RecDate`, `BankConfig`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.BankID}','{item.BankName}',{item.BankType},'{item.TrdPublicKey}','{item.OwnPublicKey}','{item.OwnPrivateKey}',{item.PayFee},{item.CashFee},'{item.Note}',{item.Status},{item.VerifyDelay},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}','{item.BankConfig}'),");
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
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string bankID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string bankID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_bankEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.BankID, tm_);
		}
		public async Task<int> RemoveAsync(Sb_bankEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.BankID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
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
		#region RemoveByBankType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankType(int bankType, TransactionManager tm_ = null)
		{
			RepairRemoveByBankTypeData(bankType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankTypeAsync(int bankType, TransactionManager tm_ = null)
		{
			RepairRemoveByBankTypeData(bankType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankTypeData(int bankType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BankType` = @BankType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32));
		}
		#endregion // RemoveByBankType
		#region RemoveByTrdPublicKey
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTrdPublicKey(string trdPublicKey, TransactionManager tm_ = null)
		{
			RepairRemoveByTrdPublicKeyData(trdPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTrdPublicKeyAsync(string trdPublicKey, TransactionManager tm_ = null)
		{
			RepairRemoveByTrdPublicKeyData(trdPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTrdPublicKeyData(string trdPublicKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (trdPublicKey != null ? "`TrdPublicKey` = @TrdPublicKey" : "`TrdPublicKey` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (trdPublicKey != null)
				paras_.Add(Database.CreateInParameter("@TrdPublicKey", trdPublicKey, MySqlDbType.Text));
		}
		#endregion // RemoveByTrdPublicKey
		#region RemoveByOwnPublicKey
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOwnPublicKey(string ownPublicKey, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnPublicKeyData(ownPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOwnPublicKeyAsync(string ownPublicKey, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnPublicKeyData(ownPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOwnPublicKeyData(string ownPublicKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (ownPublicKey != null ? "`OwnPublicKey` = @OwnPublicKey" : "`OwnPublicKey` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (ownPublicKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPublicKey", ownPublicKey, MySqlDbType.Text));
		}
		#endregion // RemoveByOwnPublicKey
		#region RemoveByOwnPrivateKey
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOwnPrivateKey(string ownPrivateKey, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnPrivateKeyData(ownPrivateKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOwnPrivateKeyAsync(string ownPrivateKey, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnPrivateKeyData(ownPrivateKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOwnPrivateKeyData(string ownPrivateKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (ownPrivateKey != null ? "`OwnPrivateKey` = @OwnPrivateKey" : "`OwnPrivateKey` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (ownPrivateKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey, MySqlDbType.Text));
		}
		#endregion // RemoveByOwnPrivateKey
		#region RemoveByPayFee
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayFee(decimal payFee, TransactionManager tm_ = null)
		{
			RepairRemoveByPayFeeData(payFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayFeeAsync(decimal payFee, TransactionManager tm_ = null)
		{
			RepairRemoveByPayFeeData(payFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayFeeData(decimal payFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayFee` = @PayFee";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByPayFee
		#region RemoveByCashFee
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashFee(decimal cashFee, TransactionManager tm_ = null)
		{
			RepairRemoveByCashFeeData(cashFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashFeeAsync(decimal cashFee, TransactionManager tm_ = null)
		{
			RepairRemoveByCashFeeData(cashFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashFeeData(decimal cashFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashFee` = @CashFee";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByCashFee
		#region RemoveByNote
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByNote(string note, TransactionManager tm_ = null)
		{
			RepairRemoveByNoteData(note, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByNoteAsync(string note, TransactionManager tm_ = null)
		{
			RepairRemoveByNoteData(note, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByNoteData(string note, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (note != null ? "`Note` = @Note" : "`Note` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
		}
		#endregion // RemoveByNote
		#region RemoveByStatus
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
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
		#region RemoveByVerifyDelay
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByVerifyDelay(int verifyDelay, TransactionManager tm_ = null)
		{
			RepairRemoveByVerifyDelayData(verifyDelay, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByVerifyDelayAsync(int verifyDelay, TransactionManager tm_ = null)
		{
			RepairRemoveByVerifyDelayData(verifyDelay, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByVerifyDelayData(int verifyDelay, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `VerifyDelay` = @VerifyDelay";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32));
		}
		#endregion // RemoveByVerifyDelay
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
		#region RemoveByBankConfig
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBankConfig(string bankConfig, TransactionManager tm_ = null)
		{
			RepairRemoveByBankConfigData(bankConfig, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBankConfigAsync(string bankConfig, TransactionManager tm_ = null)
		{
			RepairRemoveByBankConfigData(bankConfig, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBankConfigData(string bankConfig, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (bankConfig != null ? "`BankConfig` = @BankConfig" : "`BankConfig` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (bankConfig != null)
				paras_.Add(Database.CreateInParameter("@BankConfig", bankConfig, MySqlDbType.Text));
		}
		#endregion // RemoveByBankConfig
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
		public int Put(Sb_bankEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_bankEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_bankEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankID` = @BankID, `BankName` = @BankName, `BankType` = @BankType, `TrdPublicKey` = @TrdPublicKey, `OwnPublicKey` = @OwnPublicKey, `OwnPrivateKey` = @OwnPrivateKey, `PayFee` = @PayFee, `CashFee` = @CashFee, `Note` = @Note, `Status` = @Status, `VerifyDelay` = @VerifyDelay, `BankConfig` = @BankConfig WHERE `BankID` = @BankID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", item.BankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankType", item.BankType, MySqlDbType.Int32),
				Database.CreateInParameter("@TrdPublicKey", item.TrdPublicKey != null ? item.TrdPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OwnPublicKey", item.OwnPublicKey != null ? item.OwnPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@OwnPrivateKey", item.OwnPrivateKey != null ? item.OwnPrivateKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@PayFee", item.PayFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@CashFee", item.CashFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@Note", item.Note != null ? item.Note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@Status", item.Status, MySqlDbType.Int32),
				Database.CreateInParameter("@VerifyDelay", item.VerifyDelay, MySqlDbType.Int32),
				Database.CreateInParameter("@BankConfig", item.BankConfig != null ? item.BankConfig : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@BankID_Original", item.HasOriginal ? item.OriginalBankID : item.BankID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_bankEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_bankEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string set_, params object[] values_)
		{
			return Put(set_, "`BankID` = @BankID", ConcatValues(values_, bankID));
		}
		public async Task<int> PutByPKAsync(string bankID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`BankID` = @BankID", ConcatValues(values_, bankID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`BankID` = @BankID", tm_, ConcatValues(values_, bankID));
		}
		public async Task<int> PutByPKAsync(string bankID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`BankID` = @BankID", tm_, ConcatValues(values_, bankID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`BankID` = @BankID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string bankID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`BankID` = @BankID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutBankName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankNameByPK(string bankID, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankID, bankName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankNameByPKAsync(string bankID, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankID, bankName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankNameByPKData(string bankID, string bankName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankName` = @BankName  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
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
		#region PutBankType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankTypeByPK(string bankID, int bankType, TransactionManager tm_ = null)
		{
			RepairPutBankTypeByPKData(bankID, bankType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankTypeByPKAsync(string bankID, int bankType, TransactionManager tm_ = null)
		{
			RepairPutBankTypeByPKData(bankID, bankType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankTypeByPKData(string bankID, int bankType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankType` = @BankType  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankType(int bankType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankType` = @BankType";
			var parameter_ = Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankTypeAsync(int bankType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankType` = @BankType";
			var parameter_ = Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankType
		#region PutTrdPublicKey
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTrdPublicKeyByPK(string bankID, string trdPublicKey, TransactionManager tm_ = null)
		{
			RepairPutTrdPublicKeyByPKData(bankID, trdPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTrdPublicKeyByPKAsync(string bankID, string trdPublicKey, TransactionManager tm_ = null)
		{
			RepairPutTrdPublicKeyByPKData(bankID, trdPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTrdPublicKeyByPKData(string bankID, string trdPublicKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TrdPublicKey` = @TrdPublicKey  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TrdPublicKey", trdPublicKey != null ? trdPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTrdPublicKey(string trdPublicKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TrdPublicKey` = @TrdPublicKey";
			var parameter_ = Database.CreateInParameter("@TrdPublicKey", trdPublicKey != null ? trdPublicKey : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTrdPublicKeyAsync(string trdPublicKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TrdPublicKey` = @TrdPublicKey";
			var parameter_ = Database.CreateInParameter("@TrdPublicKey", trdPublicKey != null ? trdPublicKey : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTrdPublicKey
		#region PutOwnPublicKey
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnPublicKeyByPK(string bankID, string ownPublicKey, TransactionManager tm_ = null)
		{
			RepairPutOwnPublicKeyByPKData(bankID, ownPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOwnPublicKeyByPKAsync(string bankID, string ownPublicKey, TransactionManager tm_ = null)
		{
			RepairPutOwnPublicKeyByPKData(bankID, ownPublicKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOwnPublicKeyByPKData(string bankID, string ownPublicKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OwnPublicKey` = @OwnPublicKey  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OwnPublicKey", ownPublicKey != null ? ownPublicKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnPublicKey(string ownPublicKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnPublicKey` = @OwnPublicKey";
			var parameter_ = Database.CreateInParameter("@OwnPublicKey", ownPublicKey != null ? ownPublicKey : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOwnPublicKeyAsync(string ownPublicKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnPublicKey` = @OwnPublicKey";
			var parameter_ = Database.CreateInParameter("@OwnPublicKey", ownPublicKey != null ? ownPublicKey : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOwnPublicKey
		#region PutOwnPrivateKey
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnPrivateKeyByPK(string bankID, string ownPrivateKey, TransactionManager tm_ = null)
		{
			RepairPutOwnPrivateKeyByPKData(bankID, ownPrivateKey, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOwnPrivateKeyByPKAsync(string bankID, string ownPrivateKey, TransactionManager tm_ = null)
		{
			RepairPutOwnPrivateKeyByPKData(bankID, ownPrivateKey, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOwnPrivateKeyByPKData(string bankID, string ownPrivateKey, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OwnPrivateKey` = @OwnPrivateKey  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey != null ? ownPrivateKey : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnPrivateKey(string ownPrivateKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnPrivateKey` = @OwnPrivateKey";
			var parameter_ = Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey != null ? ownPrivateKey : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOwnPrivateKeyAsync(string ownPrivateKey, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnPrivateKey` = @OwnPrivateKey";
			var parameter_ = Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey != null ? ownPrivateKey : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOwnPrivateKey
		#region PutPayFee
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayFeeByPK(string bankID, decimal payFee, TransactionManager tm_ = null)
		{
			RepairPutPayFeeByPKData(bankID, payFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayFeeByPKAsync(string bankID, decimal payFee, TransactionManager tm_ = null)
		{
			RepairPutPayFeeByPKData(bankID, payFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayFeeByPKData(string bankID, decimal payFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayFee` = @PayFee  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayFee(decimal payFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayFee` = @PayFee";
			var parameter_ = Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayFeeAsync(decimal payFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayFee` = @PayFee";
			var parameter_ = Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayFee
		#region PutCashFee
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashFeeByPK(string bankID, decimal cashFee, TransactionManager tm_ = null)
		{
			RepairPutCashFeeByPKData(bankID, cashFee, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashFeeByPKAsync(string bankID, decimal cashFee, TransactionManager tm_ = null)
		{
			RepairPutCashFeeByPKData(bankID, cashFee, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashFeeByPKData(string bankID, decimal cashFee, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashFee` = @CashFee  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashFee(decimal cashFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashFee` = @CashFee";
			var parameter_ = Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashFeeAsync(decimal cashFee, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashFee` = @CashFee";
			var parameter_ = Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashFee
		#region PutNote
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "note">备注信息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNoteByPK(string bankID, string note, TransactionManager tm_ = null)
		{
			RepairPutNoteByPKData(bankID, note, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutNoteByPKAsync(string bankID, string note, TransactionManager tm_ = null)
		{
			RepairPutNoteByPKData(bankID, note, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutNoteByPKData(string bankID, string note, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Note` = @Note  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNote(string note, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutNoteAsync(string note, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Note` = @Note";
			var parameter_ = Database.CreateInParameter("@Note", note != null ? note : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutNote
		#region PutStatus
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutStatusByPK(string bankID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(bankID, status, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutStatusByPKAsync(string bankID, int status, TransactionManager tm_ = null)
		{
			RepairPutStatusByPKData(bankID, status, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutStatusByPKData(string bankID, int status, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Status` = @Status  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Status", status, MySqlDbType.Int32),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
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
		#region PutVerifyDelay
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVerifyDelayByPK(string bankID, int verifyDelay, TransactionManager tm_ = null)
		{
			RepairPutVerifyDelayByPKData(bankID, verifyDelay, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutVerifyDelayByPKAsync(string bankID, int verifyDelay, TransactionManager tm_ = null)
		{
			RepairPutVerifyDelayByPKData(bankID, verifyDelay, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutVerifyDelayByPKData(string bankID, int verifyDelay, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `VerifyDelay` = @VerifyDelay  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVerifyDelay(int verifyDelay, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VerifyDelay` = @VerifyDelay";
			var parameter_ = Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutVerifyDelayAsync(int verifyDelay, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VerifyDelay` = @VerifyDelay";
			var parameter_ = Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutVerifyDelay
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string bankID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(bankID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string bankID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(bankID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string bankID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
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
		#region PutBankConfig
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankConfigByPK(string bankID, string bankConfig, TransactionManager tm_ = null)
		{
			RepairPutBankConfigByPKData(bankID, bankConfig, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankConfigByPKAsync(string bankID, string bankConfig, TransactionManager tm_ = null)
		{
			RepairPutBankConfigByPKData(bankID, bankConfig, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankConfigByPKData(string bankID, string bankConfig, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankConfig` = @BankConfig  WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankConfig", bankConfig != null ? bankConfig : (object)DBNull.Value, MySqlDbType.Text),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankConfig(string bankConfig, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankConfig` = @BankConfig";
			var parameter_ = Database.CreateInParameter("@BankConfig", bankConfig != null ? bankConfig : (object)DBNull.Value, MySqlDbType.Text);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankConfigAsync(string bankConfig, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankConfig` = @BankConfig";
			var parameter_ = Database.CreateInParameter("@BankConfig", bankConfig != null ? bankConfig : (object)DBNull.Value, MySqlDbType.Text);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankConfig
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_bankEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankID) == null)
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
		public async Task<bool> SetAsync(Sb_bankEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankID) == null)
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
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_bankEO GetByPK(string bankID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<Sb_bankEO> GetByPKAsync(string bankID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		private void RepairGetByPKData(string bankID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`BankID` = @BankID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 BankName（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankNameByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankName`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetBankNameByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankName`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankType（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetBankTypeByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`BankType`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<int> GetBankTypeByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`BankType`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TrdPublicKey（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetTrdPublicKeyByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`TrdPublicKey`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetTrdPublicKeyByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`TrdPublicKey`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OwnPublicKey（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOwnPublicKeyByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OwnPublicKey`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetOwnPublicKeyByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OwnPublicKey`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OwnPrivateKey（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOwnPrivateKeyByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OwnPrivateKey`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetOwnPrivateKeyByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OwnPrivateKey`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayFee（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetPayFeeByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`PayFee`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<decimal> GetPayFeeByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`PayFee`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashFee（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetCashFeeByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`CashFee`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<decimal> GetCashFeeByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`CashFee`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Note（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetNoteByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`Note`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetNoteByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`Note`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 Status（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetStatusByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`Status`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<int> GetStatusByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`Status`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 VerifyDelay（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetVerifyDelayByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`VerifyDelay`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<int> GetVerifyDelayByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`VerifyDelay`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`BankID` = @BankID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankConfig（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankConfigByPK(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankConfig`", "`BankID` = @BankID", paras_, tm_);
		}
		public async Task<string> GetBankConfigByPKAsync(string bankID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankConfig`", "`BankID` = @BankID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByBankName
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankName(string bankName)
		{
			return GetByBankName(bankName, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankName(string bankName, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankName(string bankName, int top_)
		{
			return GetByBankName(bankName, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, int top_)
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
		public List<Sb_bankEO> GetByBankName(string bankName, int top_, TransactionManager tm_)
		{
			return GetByBankName(bankName, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, int top_, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankName(string bankName, string sort_)
		{
			return GetByBankName(bankName, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, string sort_)
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
		public List<Sb_bankEO> GetByBankName(string bankName, string sort_, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, string sort_, TransactionManager tm_)
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
		public List<Sb_bankEO> GetByBankName(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByBankNameAsync(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByBankName
		#region GetByBankType
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType)
		{
			return GetByBankType(bankType, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType)
		{
			return await GetByBankTypeAsync(bankType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, TransactionManager tm_)
		{
			return GetByBankType(bankType, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, TransactionManager tm_)
		{
			return await GetByBankTypeAsync(bankType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, int top_)
		{
			return GetByBankType(bankType, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, int top_)
		{
			return await GetByBankTypeAsync(bankType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, int top_, TransactionManager tm_)
		{
			return GetByBankType(bankType, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, int top_, TransactionManager tm_)
		{
			return await GetByBankTypeAsync(bankType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, string sort_)
		{
			return GetByBankType(bankType, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, string sort_)
		{
			return await GetByBankTypeAsync(bankType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, string sort_, TransactionManager tm_)
		{
			return GetByBankType(bankType, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, string sort_, TransactionManager tm_)
		{
			return await GetByBankTypeAsync(bankType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankType（字段） 查询
		/// </summary>
		/// /// <param name = "bankType">银行类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankType(int bankType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankType` = @BankType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByBankTypeAsync(int bankType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankType` = @BankType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankType", bankType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByBankType
		#region GetByTrdPublicKey
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey)
		{
			return GetByTrdPublicKey(trdPublicKey, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, TransactionManager tm_)
		{
			return GetByTrdPublicKey(trdPublicKey, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, TransactionManager tm_)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, int top_)
		{
			return GetByTrdPublicKey(trdPublicKey, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, int top_)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, int top_, TransactionManager tm_)
		{
			return GetByTrdPublicKey(trdPublicKey, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, int top_, TransactionManager tm_)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, string sort_)
		{
			return GetByTrdPublicKey(trdPublicKey, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, string sort_)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, string sort_, TransactionManager tm_)
		{
			return GetByTrdPublicKey(trdPublicKey, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, string sort_, TransactionManager tm_)
		{
			return await GetByTrdPublicKeyAsync(trdPublicKey, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TrdPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "trdPublicKey">第三方公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByTrdPublicKey(string trdPublicKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(trdPublicKey != null ? "`TrdPublicKey` = @TrdPublicKey" : "`TrdPublicKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (trdPublicKey != null)
				paras_.Add(Database.CreateInParameter("@TrdPublicKey", trdPublicKey, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByTrdPublicKeyAsync(string trdPublicKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(trdPublicKey != null ? "`TrdPublicKey` = @TrdPublicKey" : "`TrdPublicKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (trdPublicKey != null)
				paras_.Add(Database.CreateInParameter("@TrdPublicKey", trdPublicKey, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByTrdPublicKey
		#region GetByOwnPublicKey
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey)
		{
			return GetByOwnPublicKey(ownPublicKey, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, TransactionManager tm_)
		{
			return GetByOwnPublicKey(ownPublicKey, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, TransactionManager tm_)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, int top_)
		{
			return GetByOwnPublicKey(ownPublicKey, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, int top_)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, int top_, TransactionManager tm_)
		{
			return GetByOwnPublicKey(ownPublicKey, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, int top_, TransactionManager tm_)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, string sort_)
		{
			return GetByOwnPublicKey(ownPublicKey, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, string sort_)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, string sort_, TransactionManager tm_)
		{
			return GetByOwnPublicKey(ownPublicKey, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, string sort_, TransactionManager tm_)
		{
			return await GetByOwnPublicKeyAsync(ownPublicKey, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OwnPublicKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPublicKey">我方的公钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPublicKey(string ownPublicKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownPublicKey != null ? "`OwnPublicKey` = @OwnPublicKey" : "`OwnPublicKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownPublicKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPublicKey", ownPublicKey, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPublicKeyAsync(string ownPublicKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownPublicKey != null ? "`OwnPublicKey` = @OwnPublicKey" : "`OwnPublicKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownPublicKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPublicKey", ownPublicKey, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByOwnPublicKey
		#region GetByOwnPrivateKey
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey)
		{
			return GetByOwnPrivateKey(ownPrivateKey, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, TransactionManager tm_)
		{
			return GetByOwnPrivateKey(ownPrivateKey, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, TransactionManager tm_)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, int top_)
		{
			return GetByOwnPrivateKey(ownPrivateKey, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, int top_)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, int top_, TransactionManager tm_)
		{
			return GetByOwnPrivateKey(ownPrivateKey, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, int top_, TransactionManager tm_)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, string sort_)
		{
			return GetByOwnPrivateKey(ownPrivateKey, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, string sort_)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, string sort_, TransactionManager tm_)
		{
			return GetByOwnPrivateKey(ownPrivateKey, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, string sort_, TransactionManager tm_)
		{
			return await GetByOwnPrivateKeyAsync(ownPrivateKey, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OwnPrivateKey（字段） 查询
		/// </summary>
		/// /// <param name = "ownPrivateKey">我方的私钥</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByOwnPrivateKey(string ownPrivateKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownPrivateKey != null ? "`OwnPrivateKey` = @OwnPrivateKey" : "`OwnPrivateKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownPrivateKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByOwnPrivateKeyAsync(string ownPrivateKey, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownPrivateKey != null ? "`OwnPrivateKey` = @OwnPrivateKey" : "`OwnPrivateKey` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownPrivateKey != null)
				paras_.Add(Database.CreateInParameter("@OwnPrivateKey", ownPrivateKey, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByOwnPrivateKey
		#region GetByPayFee
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee)
		{
			return GetByPayFee(payFee, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee)
		{
			return await GetByPayFeeAsync(payFee, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, TransactionManager tm_)
		{
			return GetByPayFee(payFee, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, TransactionManager tm_)
		{
			return await GetByPayFeeAsync(payFee, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, int top_)
		{
			return GetByPayFee(payFee, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, int top_)
		{
			return await GetByPayFeeAsync(payFee, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, int top_, TransactionManager tm_)
		{
			return GetByPayFee(payFee, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, int top_, TransactionManager tm_)
		{
			return await GetByPayFeeAsync(payFee, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, string sort_)
		{
			return GetByPayFee(payFee, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, string sort_)
		{
			return await GetByPayFeeAsync(payFee, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, string sort_, TransactionManager tm_)
		{
			return GetByPayFee(payFee, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, string sort_, TransactionManager tm_)
		{
			return await GetByPayFeeAsync(payFee, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayFee（字段） 查询
		/// </summary>
		/// /// <param name = "payFee">充值费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByPayFee(decimal payFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayFee` = @PayFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByPayFeeAsync(decimal payFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayFee` = @PayFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayFee", payFee, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByPayFee
		#region GetByCashFee
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee)
		{
			return GetByCashFee(cashFee, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee)
		{
			return await GetByCashFeeAsync(cashFee, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, TransactionManager tm_)
		{
			return GetByCashFee(cashFee, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, TransactionManager tm_)
		{
			return await GetByCashFeeAsync(cashFee, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, int top_)
		{
			return GetByCashFee(cashFee, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, int top_)
		{
			return await GetByCashFeeAsync(cashFee, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, int top_, TransactionManager tm_)
		{
			return GetByCashFee(cashFee, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, int top_, TransactionManager tm_)
		{
			return await GetByCashFeeAsync(cashFee, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, string sort_)
		{
			return GetByCashFee(cashFee, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, string sort_)
		{
			return await GetByCashFeeAsync(cashFee, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, string sort_, TransactionManager tm_)
		{
			return GetByCashFee(cashFee, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, string sort_, TransactionManager tm_)
		{
			return await GetByCashFeeAsync(cashFee, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashFee（字段） 查询
		/// </summary>
		/// /// <param name = "cashFee">提现费率</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByCashFee(decimal cashFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashFee` = @CashFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByCashFeeAsync(decimal cashFee, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashFee` = @CashFee", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashFee", cashFee, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByCashFee
		#region GetByNote
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note)
		{
			return GetByNote(note, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note)
		{
			return await GetByNoteAsync(note, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, TransactionManager tm_)
		{
			return GetByNote(note, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, TransactionManager tm_)
		{
			return await GetByNoteAsync(note, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, int top_)
		{
			return GetByNote(note, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, int top_)
		{
			return await GetByNoteAsync(note, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, int top_, TransactionManager tm_)
		{
			return GetByNote(note, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, int top_, TransactionManager tm_)
		{
			return await GetByNoteAsync(note, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, string sort_)
		{
			return GetByNote(note, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, string sort_)
		{
			return await GetByNoteAsync(note, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, string sort_, TransactionManager tm_)
		{
			return GetByNote(note, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, string sort_, TransactionManager tm_)
		{
			return await GetByNoteAsync(note, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Note（字段） 查询
		/// </summary>
		/// /// <param name = "note">备注信息</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByNote(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByNoteAsync(string note, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(note != null ? "`Note` = @Note" : "`Note` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (note != null)
				paras_.Add(Database.CreateInParameter("@Note", note, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByNote
		#region GetByStatus
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status)
		{
			return GetByStatus(status, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status)
		{
			return await GetByStatusAsync(status, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, TransactionManager tm_)
		{
			return GetByStatus(status, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, int top_)
		{
			return GetByStatus(status, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, int top_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, int top_, TransactionManager tm_)
		{
			return GetByStatus(status, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, int top_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, string sort_)
		{
			return GetByStatus(status, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, string sort_)
		{
			return await GetByStatusAsync(status, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, string sort_, TransactionManager tm_)
		{
			return GetByStatus(status, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, string sort_, TransactionManager tm_)
		{
			return await GetByStatusAsync(status, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Status（字段） 查询
		/// </summary>
		/// /// <param name = "status">状态(0-无效1-有效)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByStatus(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByStatusAsync(int status, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`Status` = @Status", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@Status", status, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByStatus
		#region GetByVerifyDelay
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay)
		{
			return GetByVerifyDelay(verifyDelay, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay)
		{
			return await GetByVerifyDelayAsync(verifyDelay, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, TransactionManager tm_)
		{
			return GetByVerifyDelay(verifyDelay, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, TransactionManager tm_)
		{
			return await GetByVerifyDelayAsync(verifyDelay, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, int top_)
		{
			return GetByVerifyDelay(verifyDelay, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, int top_)
		{
			return await GetByVerifyDelayAsync(verifyDelay, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, int top_, TransactionManager tm_)
		{
			return GetByVerifyDelay(verifyDelay, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, int top_, TransactionManager tm_)
		{
			return await GetByVerifyDelayAsync(verifyDelay, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, string sort_)
		{
			return GetByVerifyDelay(verifyDelay, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, string sort_)
		{
			return await GetByVerifyDelayAsync(verifyDelay, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, string sort_, TransactionManager tm_)
		{
			return GetByVerifyDelay(verifyDelay, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, string sort_, TransactionManager tm_)
		{
			return await GetByVerifyDelayAsync(verifyDelay, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 VerifyDelay（字段） 查询
		/// </summary>
		/// /// <param name = "verifyDelay">验证三方订单调用延时（单位毫秒）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByVerifyDelay(int verifyDelay, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`VerifyDelay` = @VerifyDelay", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByVerifyDelayAsync(int verifyDelay, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`VerifyDelay` = @VerifyDelay", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@VerifyDelay", verifyDelay, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByVerifyDelay
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sb_bankEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#region GetByBankConfig
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig)
		{
			return GetByBankConfig(bankConfig, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig)
		{
			return await GetByBankConfigAsync(bankConfig, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, TransactionManager tm_)
		{
			return GetByBankConfig(bankConfig, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, TransactionManager tm_)
		{
			return await GetByBankConfigAsync(bankConfig, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, int top_)
		{
			return GetByBankConfig(bankConfig, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, int top_)
		{
			return await GetByBankConfigAsync(bankConfig, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, int top_, TransactionManager tm_)
		{
			return GetByBankConfig(bankConfig, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, int top_, TransactionManager tm_)
		{
			return await GetByBankConfigAsync(bankConfig, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, string sort_)
		{
			return GetByBankConfig(bankConfig, 0, sort_, null);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, string sort_)
		{
			return await GetByBankConfigAsync(bankConfig, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, string sort_, TransactionManager tm_)
		{
			return GetByBankConfig(bankConfig, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, string sort_, TransactionManager tm_)
		{
			return await GetByBankConfigAsync(bankConfig, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankConfig（字段） 查询
		/// </summary>
		/// /// <param name = "bankConfig">bank配置参数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankEO> GetByBankConfig(string bankConfig, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankConfig != null ? "`BankConfig` = @BankConfig" : "`BankConfig` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankConfig != null)
				paras_.Add(Database.CreateInParameter("@BankConfig", bankConfig, MySqlDbType.Text));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		public async Task<List<Sb_bankEO>> GetByBankConfigAsync(string bankConfig, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankConfig != null ? "`BankConfig` = @BankConfig" : "`BankConfig` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankConfig != null)
				paras_.Add(Database.CreateInParameter("@BankConfig", bankConfig, MySqlDbType.Text));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankEO.MapDataReader);
		}
		#endregion // GetByBankConfig
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
