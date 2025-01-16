/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 16: 52:31
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
	/// mongopay所支持的银行列表
	/// 【表 sb_mongopay_bankcode 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_mongopay_bankcodeEO : IRowMapper<Sb_mongopay_bankcodeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_mongopay_bankcodeEO()
		{
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
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
	        return new Dictionary<string, object>() { { "BankCode", BankCode }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 银行代码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string BankCode { get; set; }
		/// <summary>
		/// 银行名称
		/// 【字段 varchar(100)】
		/// </summary>
		[DataMember(Order = 2)]
		public string BankName { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_mongopay_bankcodeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_mongopay_bankcodeEO MapDataReader(IDataReader reader)
		{
		    Sb_mongopay_bankcodeEO ret = new Sb_mongopay_bankcodeEO();
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
	/// mongopay所支持的银行列表
	/// 【表 sb_mongopay_bankcode 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_mongopay_bankcodeMO : MySqlTableMO<Sb_mongopay_bankcodeEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_mongopay_bankcode`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_mongopay_bankcodeMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_mongopay_bankcodeMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_mongopay_bankcodeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_mongopay_bankcodeEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`BankCode`, `BankName`) VALUE (@BankCode, @BankName);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", item.BankCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sb_mongopay_bankcodeEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_mongopay_bankcodeEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_mongopay_bankcodeEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`BankCode`, `BankName`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.BankCode}','{item.BankName}'),");
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
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string bankCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string bankCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(bankCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string bankCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BankCode` = @BankCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.BankCode, tm_);
		}
		public async Task<int> RemoveAsync(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.BankCode, tm_);
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
		public int Put(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_mongopay_bankcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_mongopay_bankcodeEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankCode` = @BankCode, `BankName` = @BankName WHERE `BankCode` = @BankCode_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", item.BankCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankName", item.BankName != null ? item.BankName : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BankCode_Original", item.HasOriginal ? item.OriginalBankCode : item.BankCode, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_mongopay_bankcodeEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_mongopay_bankcodeEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankCode, string set_, params object[] values_)
		{
			return Put(set_, "`BankCode` = @BankCode", ConcatValues(values_, bankCode));
		}
		public async Task<int> PutByPKAsync(string bankCode, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`BankCode` = @BankCode", ConcatValues(values_, bankCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`BankCode` = @BankCode", tm_, ConcatValues(values_, bankCode));
		}
		public async Task<int> PutByPKAsync(string bankCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`BankCode` = @BankCode", tm_, ConcatValues(values_, bankCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string bankCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
	        };
			return Put(set_, "`BankCode` = @BankCode", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string bankCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`BankCode` = @BankCode", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutBankName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBankNameByPK(string bankCode, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankCode, bankName, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBankNameByPKAsync(string bankCode, string bankName, TransactionManager tm_ = null)
		{
			RepairPutBankNameByPKData(bankCode, bankName, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBankNameByPKData(string bankCode, string bankName, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BankName` = @BankName  WHERE `BankCode` = @BankCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankName", bankName != null ? bankName : (object)DBNull.Value, MySqlDbType.VarChar),
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
		public bool Set(Sb_mongopay_bankcodeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankCode) == null)
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
		public async Task<bool> SetAsync(Sb_mongopay_bankcodeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.BankCode) == null)
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
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_mongopay_bankcodeEO GetByPK(string bankCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_mongopay_bankcodeEO.MapDataReader);
		}
		public async Task<Sb_mongopay_bankcodeEO> GetByPKAsync(string bankCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(bankCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_mongopay_bankcodeEO.MapDataReader);
		}
		private void RepairGetByPKData(string bankCode, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`BankCode` = @BankCode", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 BankName（字段）
		/// </summary>
		/// /// <param name = "bankCode">银行代码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBankNameByPK(string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BankName`", "`BankCode` = @BankCode", paras_, tm_);
		}
		public async Task<string> GetBankNameByPKAsync(string bankCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BankCode", bankCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BankName`", "`BankCode` = @BankCode", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByBankName
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <return>实体对象集合</return>
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName)
		{
			return GetByBankName(bankName, 0, string.Empty, null);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, int top_)
		{
			return GetByBankName(bankName, top_, string.Empty, null);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, int top_)
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
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, int top_, TransactionManager tm_)
		{
			return GetByBankName(bankName, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, int top_, TransactionManager tm_)
		{
			return await GetByBankNameAsync(bankName, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BankName（字段） 查询
		/// </summary>
		/// /// <param name = "bankName">银行名称</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, string sort_)
		{
			return GetByBankName(bankName, 0, sort_, null);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, string sort_)
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
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, string sort_, TransactionManager tm_)
		{
			return GetByBankName(bankName, 0, sort_, tm_);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, string sort_, TransactionManager tm_)
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
		public List<Sb_mongopay_bankcodeEO> GetByBankName(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_mongopay_bankcodeEO.MapDataReader);
		}
		public async Task<List<Sb_mongopay_bankcodeEO>> GetByBankNameAsync(string bankName, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(bankName != null ? "`BankName` = @BankName" : "`BankName` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (bankName != null)
				paras_.Add(Database.CreateInParameter("@BankName", bankName, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_mongopay_bankcodeEO.MapDataReader);
		}
		#endregion // GetByBankName
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
