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
	/// 支付方式：visa，电子钱包，spei等
	/// 【表 sb_paytype 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_paytypeEO : IRowMapper<Sb_paytypeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_paytypeEO()
		{
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private int _originalPaytypeID;
		/// <summary>
		/// 【数据库中的原始主键 PaytypeID 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalPaytypeID
		{
			get { return _originalPaytypeID; }
			set { HasOriginal = true; _originalPaytypeID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "PaytypeID", PaytypeID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 支付类型编码
		/// 【主键 int】
		/// </summary>
		[DataMember(Order = 1)]
		public int PaytypeID { get; set; }
		/// <summary>
		/// 支付类型
		/// 【字段 varchar(20)】
		/// </summary>
		[DataMember(Order = 2)]
		public string Name { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_paytypeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_paytypeEO MapDataReader(IDataReader reader)
		{
		    Sb_paytypeEO ret = new Sb_paytypeEO();
			ret.PaytypeID = reader.ToInt32("PaytypeID");
			ret.OriginalPaytypeID = ret.PaytypeID;
			ret.Name = reader.ToString("Name");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 支付方式：visa，电子钱包，spei等
	/// 【表 sb_paytype 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_paytypeMO : MySqlTableMO<Sb_paytypeEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_paytype`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_paytypeMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_paytypeMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_paytypeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_paytypeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_paytypeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_paytypeEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`PaytypeID`, `Name`) VALUE (@PaytypeID, @Name);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", item.PaytypeID, MySqlDbType.Int32),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sb_paytypeEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_paytypeEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_paytypeEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`PaytypeID`, `Name`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"({item.PaytypeID},'{item.Name}'),");
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
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(int paytypeID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(int paytypeID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(paytypeID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(int paytypeID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PaytypeID` = @PaytypeID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_paytypeEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.PaytypeID, tm_);
		}
		public async Task<int> RemoveAsync(Sb_paytypeEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.PaytypeID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByName
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByName(string name, TransactionManager tm_ = null)
		{
			RepairRemoveByNameData(name, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByNameAsync(string name, TransactionManager tm_ = null)
		{
			RepairRemoveByNameData(name, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByNameData(string name, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (name != null ? "`Name` = @Name" : "`Name` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
		}
		#endregion // RemoveByName
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
		public int Put(Sb_paytypeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_paytypeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_paytypeEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PaytypeID` = @PaytypeID, `Name` = @Name WHERE `PaytypeID` = @PaytypeID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", item.PaytypeID, MySqlDbType.Int32),
				Database.CreateInParameter("@Name", item.Name != null ? item.Name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PaytypeID_Original", item.HasOriginal ? item.OriginalPaytypeID : item.PaytypeID, MySqlDbType.Int32),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_paytypeEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_paytypeEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int paytypeID, string set_, params object[] values_)
		{
			return Put(set_, "`PaytypeID` = @PaytypeID", ConcatValues(values_, paytypeID));
		}
		public async Task<int> PutByPKAsync(int paytypeID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`PaytypeID` = @PaytypeID", ConcatValues(values_, paytypeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int paytypeID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`PaytypeID` = @PaytypeID", tm_, ConcatValues(values_, paytypeID));
		}
		public async Task<int> PutByPKAsync(int paytypeID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`PaytypeID` = @PaytypeID", tm_, ConcatValues(values_, paytypeID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int paytypeID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
	        };
			return Put(set_, "`PaytypeID` = @PaytypeID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(int paytypeID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
	        };
			return await PutAsync(set_, "`PaytypeID` = @PaytypeID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutName
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// /// <param name = "name">支付类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutNameByPK(int paytypeID, string name, TransactionManager tm_ = null)
		{
			RepairPutNameByPKData(paytypeID, name, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutNameByPKAsync(int paytypeID, string name, TransactionManager tm_ = null)
		{
			RepairPutNameByPKData(paytypeID, name, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutNameByPKData(int paytypeID, string name, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `Name` = @Name  WHERE `PaytypeID` = @PaytypeID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutName(string name, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Name` = @Name";
			var parameter_ = Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutNameAsync(string name, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `Name` = @Name";
			var parameter_ = Database.CreateInParameter("@Name", name != null ? name : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutName
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_paytypeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.PaytypeID) == null)
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
		public async Task<bool> SetAsync(Sb_paytypeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.PaytypeID) == null)
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
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_paytypeEO GetByPK(int paytypeID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(paytypeID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_paytypeEO.MapDataReader);
		}
		public async Task<Sb_paytypeEO> GetByPKAsync(int paytypeID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(paytypeID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_paytypeEO.MapDataReader);
		}
		private void RepairGetByPKData(int paytypeID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`PaytypeID` = @PaytypeID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 Name（字段）
		/// </summary>
		/// /// <param name = "paytypeID">支付类型编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetNameByPK(int paytypeID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`Name`", "`PaytypeID` = @PaytypeID", paras_, tm_);
		}
		public async Task<string> GetNameByPKAsync(int paytypeID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PaytypeID", paytypeID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`Name`", "`PaytypeID` = @PaytypeID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByName
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name)
		{
			return GetByName(name, 0, string.Empty, null);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name)
		{
			return await GetByNameAsync(name, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, TransactionManager tm_)
		{
			return GetByName(name, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, TransactionManager tm_)
		{
			return await GetByNameAsync(name, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, int top_)
		{
			return GetByName(name, top_, string.Empty, null);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, int top_)
		{
			return await GetByNameAsync(name, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, int top_, TransactionManager tm_)
		{
			return GetByName(name, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, int top_, TransactionManager tm_)
		{
			return await GetByNameAsync(name, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, string sort_)
		{
			return GetByName(name, 0, sort_, null);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, string sort_)
		{
			return await GetByNameAsync(name, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, string sort_, TransactionManager tm_)
		{
			return GetByName(name, 0, sort_, tm_);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, string sort_, TransactionManager tm_)
		{
			return await GetByNameAsync(name, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 Name（字段） 查询
		/// </summary>
		/// /// <param name = "name">支付类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_paytypeEO> GetByName(string name, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_paytypeEO.MapDataReader);
		}
		public async Task<List<Sb_paytypeEO>> GetByNameAsync(string name, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(name != null ? "`Name` = @Name" : "`Name` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (name != null)
				paras_.Add(Database.CreateInParameter("@Name", name, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_paytypeEO.MapDataReader);
		}
		#endregion // GetByName
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
