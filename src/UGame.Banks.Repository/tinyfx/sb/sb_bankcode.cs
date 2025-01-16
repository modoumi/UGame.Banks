/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-11-24 17: 39:53
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
	/// bankid代付时所支持的不同国家的银行列表
	/// 【表 sb_bankcode 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_bankcodeEO : IRowMapper<Sb_bankcodeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_bankcodeEO()
		{
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
		
		private string _originalCountryID;
		/// <summary>
		/// 【数据库中的原始主键 CountryID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalCountryID
		{
			get { return _originalCountryID; }
			set { HasOriginal = true; _originalCountryID = value; }
		}
		
		private string _originalBankCode;
		/// <summary>
		/// 【数据库中的原始主键 BankCode 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalBankCode
		{
			get { return _originalBankCode; }
			set { HasOriginal = true; _originalBankCode = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "BankID", BankID },  { "CountryID", CountryID },  { "BankCode", BankCode }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 银行编码(ing)
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string BankID { get; set; }
		/// <summary>
		/// 国家代码
		/// 【主键 varchar(10)】
		/// </summary>
		[DataMember(Order = 2)]
		public string CountryID { get; set; }
		/// <summary>
		/// 银行代码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 3)]
		public string BankCode { get; set; }
		/// <summary>
		/// 银行名称
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 4)]
		public string BankName { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_bankcodeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_bankcodeEO MapDataReader(IDataReader reader)
		{
		    Sb_bankcodeEO ret = new Sb_bankcodeEO();
			ret.BankID = reader.ToString("BankID");
			ret.OriginalBankID = ret.BankID;
			ret.CountryID = reader.ToString("CountryID");
			ret.OriginalCountryID = ret.CountryID;
			ret.BankCode = reader.ToString("BankCode");
			ret.OriginalBankCode = ret.BankCode;
			ret.BankName = reader.ToString("BankName");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// bankid代付时所支持的不同国家的银行列表
	/// 【表 sb_bankcode 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_bankcodeMO : MySqlTableMO<Sb_bankcodeEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_bankcode`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_bankcodeMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_bankcodeMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_bankcodeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_bankcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_bankcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_bankcodeEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`BankID`, `CountryID`, `BankCode`, `BankName`) VALUE (@BankID, @CountryID, @BankCode, @BankName);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", item.BankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", item.BankCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sb_bankcodeEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_bankcodeEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_bankcodeEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`BankID`, `CountryID`, `BankCode`, `BankName`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.BankID}','{item.CountryID}','{item.BankCode}','{item.BankName}'),");
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
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankID, countryID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankID, countryID, bankCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string bankID, string countryID, string bankCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_bankcodeEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.BankID, item.CountryID, item.BankCode, tm_);
		}
		public async Task<int> RemoveAsync(Sb_bankcodeEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.BankID, item.CountryID, item.BankCode, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByBankID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
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
			sql_ = $"DELETE FROM {TableName} WHERE `BankID` = @BankID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBankID
		#region RemoveByCountryID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
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
			sql_ = $"DELETE FROM {TableName} WHERE `BankCode` = @BankCode";
			paras_ = new List<MySqlParameter>();
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
		public int Put(Sb_bankcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_bankcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_bankcodeEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankID` = @BankID, `CountryID` = @CountryID, `BankCode` = @BankCode, `BankName` = @BankName WHERE `BankID` = @BankID_Original AND `CountryID` = @CountryID_Original AND `BankCode` = @BankCode_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", item.BankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", item.BankCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID_Original", item.HasOriginal ? item.OriginalBankID : item.BankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID_Original", item.HasOriginal ? item.OriginalCountryID : item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode_Original", item.HasOriginal ? item.OriginalBankCode : item.BankCode, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_bankcodeEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_bankcodeEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string countryID, string bankCode, string set_, params object[] values_)
		{
			return Put(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", ConcatValues(values_, bankID, countryID, bankCode));
		}
		public async Task<int> PutByPKAsync(string bankID, string countryID, string bankCode, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", ConcatValues(values_, bankID, countryID, bankCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string countryID, string bankCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", tm_, ConcatValues(values_, bankID, countryID, bankCode));
		}
		public async Task<int> PutByPKAsync(string bankID, string countryID, string bankCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", tm_, ConcatValues(values_, bankID, countryID, bankCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankID, string countryID, string bankCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
	        };
			return Put(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string bankID, string countryID, string bankCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutBankID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankID(string bankID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankID` = @BankID";
			var parameter_ = Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankIDAsync(string bankID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankID` = @BankID";
			var parameter_ = Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankID
		#region PutCountryID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
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
		#region PutBankCode
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankCode(string bankCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
			var parameter_ = Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBankCodeAsync(string bankCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode";
			var parameter_ = Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBankCode
		#region PutBankName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankNameByPK(string bankID, string countryID, string bankCode, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankID, countryID, bankCode, bankName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankNameByPKAsync(string bankID, string countryID, string bankCode, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankID, countryID, bankCode, bankName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankNameByPKData(string bankID, string countryID, string bankCode, string bankName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankName` = @BankName  WHERE `BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_bankcodeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankID, item.CountryID, item.BankCode) == null)
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
		public async Task<bool> SetAsync(Sb_bankcodeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankID, item.CountryID, item.BankCode) == null)
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
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_bankcodeEO GetByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankID, countryID, bankCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		public async Task<Sb_bankcodeEO> GetByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankID, countryID, bankCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		private void RepairGetByPKData(string bankID, string countryID, string bankCode, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 BankID（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankIDByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankID`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		public async Task<string> GetBankIDByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankID`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankCode（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankCodeByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankCode`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		public async Task<string> GetBankCodeByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankCode`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BankName（字段）
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// /// <param name = "countryID">国家代码</param>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankNameByPK(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankName`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		public async Task<string> GetBankNameByPKAsync(string bankID, string countryID, string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankName`", "`BankID` = @BankID AND `CountryID` = @CountryID AND `BankCode` = @BankCode", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByBankID
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID)
		{
			return GetByBankID(bankID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, int top_)
		{
			return GetByBankID(bankID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, int top_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, int top_, TransactionManager tm_)
		{
			return GetByBankID(bankID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, int top_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, string sort_)
		{
			return GetByBankID(bankID, 0, sort_, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, string sort_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, string sort_, TransactionManager tm_)
		{
			return GetByBankID(bankID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, string sort_, TransactionManager tm_)
		{
			return await GetByBankIDAsync(bankID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BankID（字段） 查询
		/// </summary>
		/// /// <param name = "bankID">银行编码(ing)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankID(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankID` = @BankID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankIDAsync(string bankID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankID` = @BankID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankID", bankID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		#endregion // GetByBankID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, int top_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, string sort_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家代码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		public async Task<List<Sb_bankcodeEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByBankCode
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode)
		{
			return GetByBankCode(bankCode, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, int top_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, int top_)
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
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, int top_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, int top_, TransactionManager tm_)
		{
			return await GetByBankCodeAsync(bankCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankCode（字段） 查询
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, string sort_)
		{
			return GetByBankCode(bankCode, 0, sort_, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, string sort_)
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
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, string sort_, TransactionManager tm_)
		{
			return GetByBankCode(bankCode, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, string sort_, TransactionManager tm_)
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
		public List<Sb_bankcodeEO> GetByBankCode(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankCode` = @BankCode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankCodeAsync(string bankCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BankCode` = @BankCode", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		#endregion // GetByBankCode
		#region GetByBankName
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankName(string bankName)
		{
			return GetByBankName(bankName, 0, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankName(string bankName, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankName(string bankName, int top_)
		{
			return GetByBankName(bankName, top_, string.Empty, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, int top_)
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
		public List<Sb_bankcodeEO> GetByBankName(string bankName, int top_, TransactionManager tm_)
		{
			return GetByBankName(bankName, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, int top_, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bankcodeEO> GetByBankName(string bankName, string sort_)
		{
			return GetByBankName(bankName, 0, sort_, null);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, string sort_)
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
		public List<Sb_bankcodeEO> GetByBankName(string bankName, string sort_, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, sort_, tm_);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, string sort_, TransactionManager tm_)
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
		public List<Sb_bankcodeEO> GetByBankName(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		public async Task<List<Sb_bankcodeEO>> GetByBankNameAsync(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bankcodeEO.MapDataReader);
		}
		#endregion // GetByBankName
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
