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
	/// spei支付个人可用序号
	/// 【表 sb_bank_spei_code 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_bank_spei_codeEO : IRowMapper<Sb_bank_spei_codeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_bank_spei_codeEO()
		{
			this.IsUsed = false;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalSpeiCode;
		/// <summary>
		/// 【数据库中的原始主键 SpeiCode 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalSpeiCode
		{
			get { return _originalSpeiCode; }
			set { HasOriginal = true; _originalSpeiCode = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "SpeiCode", SpeiCode }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// Spei支付用户标识
		/// 【主键 varchar(20)】
		/// </summary>
		[DataMember(Order = 1)]
		public string SpeiCode { get; set; }
		/// <summary>
		/// 是否使用
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 2)]
		public bool IsUsed { get; set; }
		/// <summary>
		/// 使用时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 3)]
		public DateTime? UseDate { get; set; }
		/// <summary>
		/// 用户编码(GUID)
		/// 【字段 varchar(38)】
		/// </summary>
		[DataMember(Order = 4)]
		public string UserID { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_bank_spei_codeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_bank_spei_codeEO MapDataReader(IDataReader reader)
		{
		    Sb_bank_spei_codeEO ret = new Sb_bank_spei_codeEO();
			ret.SpeiCode = reader.ToString("SpeiCode");
			ret.OriginalSpeiCode = ret.SpeiCode;
			ret.IsUsed = reader.ToBoolean("IsUsed");
			ret.UseDate = reader.ToDateTimeN("UseDate");
			ret.UserID = reader.ToString("UserID");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// spei支付个人可用序号
	/// 【表 sb_bank_spei_code 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_bank_spei_codeMO : MySqlTableMO<Sb_bank_spei_codeEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_bank_spei_code`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_bank_spei_codeMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_bank_spei_codeMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_bank_spei_codeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_bank_spei_codeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_bank_spei_codeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_bank_spei_codeEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`SpeiCode`, `IsUsed`, `UseDate`, `UserID`) VALUE (@SpeiCode, @IsUsed, @UseDate, @UserID);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", item.SpeiCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsUsed", item.IsUsed, MySqlDbType.Byte),
				Database.CreateInParameter("@UseDate", item.UseDate.HasValue ? item.UseDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@UserID", item.UserID != null ? item.UserID : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sb_bank_spei_codeEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_bank_spei_codeEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_bank_spei_codeEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`SpeiCode`, `IsUsed`, `UseDate`, `UserID`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.SpeiCode}',{item.IsUsed},'{item.UseDate?.ToString("yyyy-MM-dd HH:mm:ss")}','{item.UserID}'),");
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
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string speiCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(speiCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string speiCode, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(speiCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string speiCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `SpeiCode` = @SpeiCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_bank_spei_codeEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.SpeiCode, tm_);
		}
		public async Task<int> RemoveAsync(Sb_bank_spei_codeEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.SpeiCode, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByIsUsed
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsUsed(bool isUsed, TransactionManager tm_ = null)
		{
			RepairRemoveByIsUsedData(isUsed, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsUsedAsync(bool isUsed, TransactionManager tm_ = null)
		{
			RepairRemoveByIsUsedData(isUsed, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsUsedData(bool isUsed, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsUsed` = @IsUsed";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsUsed
		#region RemoveByUseDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByUseDate(DateTime? useDate, TransactionManager tm_ = null)
		{
			RepairRemoveByUseDateData(useDate.Value, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByUseDateAsync(DateTime? useDate, TransactionManager tm_ = null)
		{
			RepairRemoveByUseDateData(useDate.Value, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByUseDateData(DateTime? useDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (useDate.HasValue ? "`UseDate` = @UseDate" : "`UseDate` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (useDate.HasValue)
				paras_.Add(Database.CreateInParameter("@UseDate", useDate.Value, MySqlDbType.DateTime));
		}
		#endregion // RemoveByUseDate
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
		public int Put(Sb_bank_spei_codeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_bank_spei_codeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_bank_spei_codeEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `SpeiCode` = @SpeiCode, `IsUsed` = @IsUsed, `UseDate` = @UseDate, `UserID` = @UserID WHERE `SpeiCode` = @SpeiCode_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", item.SpeiCode, MySqlDbType.VarChar),
				Database.CreateInParameter("@IsUsed", item.IsUsed, MySqlDbType.Byte),
				Database.CreateInParameter("@UseDate", item.UseDate.HasValue ? item.UseDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@UserID", item.UserID != null ? item.UserID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SpeiCode_Original", item.HasOriginal ? item.OriginalSpeiCode : item.SpeiCode, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_bank_spei_codeEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_bank_spei_codeEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string speiCode, string set_, params object[] values_)
		{
			return Put(set_, "`SpeiCode` = @SpeiCode", ConcatValues(values_, speiCode));
		}
		public async Task<int> PutByPKAsync(string speiCode, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`SpeiCode` = @SpeiCode", ConcatValues(values_, speiCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string speiCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`SpeiCode` = @SpeiCode", tm_, ConcatValues(values_, speiCode));
		}
		public async Task<int> PutByPKAsync(string speiCode, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`SpeiCode` = @SpeiCode", tm_, ConcatValues(values_, speiCode));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string speiCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
	        };
			return Put(set_, "`SpeiCode` = @SpeiCode", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string speiCode, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`SpeiCode` = @SpeiCode", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutIsUsed
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsUsedByPK(string speiCode, bool isUsed, TransactionManager tm_ = null)
		{
			RepairPutIsUsedByPKData(speiCode, isUsed, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsUsedByPKAsync(string speiCode, bool isUsed, TransactionManager tm_ = null)
		{
			RepairPutIsUsedByPKData(speiCode, isUsed, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsUsedByPKData(string speiCode, bool isUsed, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsUsed` = @IsUsed  WHERE `SpeiCode` = @SpeiCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte),
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsUsed(bool isUsed, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsUsed` = @IsUsed";
			var parameter_ = Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsUsedAsync(bool isUsed, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsUsed` = @IsUsed";
			var parameter_ = Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsUsed
		#region PutUseDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUseDateByPK(string speiCode, DateTime? useDate, TransactionManager tm_ = null)
		{
			RepairPutUseDateByPKData(speiCode, useDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUseDateByPKAsync(string speiCode, DateTime? useDate, TransactionManager tm_ = null)
		{
			RepairPutUseDateByPKData(speiCode, useDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUseDateByPKData(string speiCode, DateTime? useDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UseDate` = @UseDate  WHERE `SpeiCode` = @SpeiCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UseDate", useDate.HasValue ? useDate.Value : (object)DBNull.Value, MySqlDbType.DateTime),
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUseDate(DateTime? useDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UseDate` = @UseDate";
			var parameter_ = Database.CreateInParameter("@UseDate", useDate.HasValue ? useDate.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutUseDateAsync(DateTime? useDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `UseDate` = @UseDate";
			var parameter_ = Database.CreateInParameter("@UseDate", useDate.HasValue ? useDate.Value : (object)DBNull.Value, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutUseDate
		#region PutUserID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutUserIDByPK(string speiCode, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(speiCode, userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutUserIDByPKAsync(string speiCode, string userID, TransactionManager tm_ = null)
		{
			RepairPutUserIDByPKData(speiCode, userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutUserIDByPKData(string speiCode, string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID  WHERE `SpeiCode` = @SpeiCode";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID != null ? userID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
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
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_bank_spei_codeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.SpeiCode) == null)
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
		public async Task<bool> SetAsync(Sb_bank_spei_codeEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.SpeiCode) == null)
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
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_bank_spei_codeEO GetByPK(string speiCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(speiCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		public async Task<Sb_bank_spei_codeEO> GetByPKAsync(string speiCode, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(speiCode, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		private void RepairGetByPKData(string speiCode, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`SpeiCode` = @SpeiCode", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 IsUsed（字段）
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsUsedByPK(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsUsed`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		public async Task<bool> GetIsUsedByPKAsync(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsUsed`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UseDate（字段）
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime? GetUseDateByPK(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (DateTime?)GetScalar("`UseDate`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		public async Task<DateTime?> GetUseDateByPKAsync(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (DateTime?)await GetScalarAsync("`UseDate`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 UserID（字段）
		/// </summary>
		/// /// <param name = "speiCode">Spei支付用户标识</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetUserIDByPK(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`UserID`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		public async Task<string> GetUserIDByPKAsync(string speiCode, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@SpeiCode", speiCode, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`UserID`", "`SpeiCode` = @SpeiCode", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByIsUsed
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed)
		{
			return GetByIsUsed(isUsed, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed)
		{
			return await GetByIsUsedAsync(isUsed, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, TransactionManager tm_)
		{
			return GetByIsUsed(isUsed, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, TransactionManager tm_)
		{
			return await GetByIsUsedAsync(isUsed, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, int top_)
		{
			return GetByIsUsed(isUsed, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, int top_)
		{
			return await GetByIsUsedAsync(isUsed, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, int top_, TransactionManager tm_)
		{
			return GetByIsUsed(isUsed, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, int top_, TransactionManager tm_)
		{
			return await GetByIsUsedAsync(isUsed, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, string sort_)
		{
			return GetByIsUsed(isUsed, 0, sort_, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, string sort_)
		{
			return await GetByIsUsedAsync(isUsed, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, string sort_, TransactionManager tm_)
		{
			return GetByIsUsed(isUsed, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, string sort_, TransactionManager tm_)
		{
			return await GetByIsUsedAsync(isUsed, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsUsed（字段） 查询
		/// </summary>
		/// /// <param name = "isUsed">是否使用</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByIsUsed(bool isUsed, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsUsed` = @IsUsed", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByIsUsedAsync(bool isUsed, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsUsed` = @IsUsed", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsUsed", isUsed, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		#endregion // GetByIsUsed
		#region GetByUseDate
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate)
		{
			return GetByUseDate(useDate, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate)
		{
			return await GetByUseDateAsync(useDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, TransactionManager tm_)
		{
			return GetByUseDate(useDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, TransactionManager tm_)
		{
			return await GetByUseDateAsync(useDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, int top_)
		{
			return GetByUseDate(useDate, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, int top_)
		{
			return await GetByUseDateAsync(useDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, int top_, TransactionManager tm_)
		{
			return GetByUseDate(useDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, int top_, TransactionManager tm_)
		{
			return await GetByUseDateAsync(useDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, string sort_)
		{
			return GetByUseDate(useDate, 0, sort_, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, string sort_)
		{
			return await GetByUseDateAsync(useDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, string sort_, TransactionManager tm_)
		{
			return GetByUseDate(useDate, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, string sort_, TransactionManager tm_)
		{
			return await GetByUseDateAsync(useDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 UseDate（字段） 查询
		/// </summary>
		/// /// <param name = "useDate">使用时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUseDate(DateTime? useDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(useDate.HasValue ? "`UseDate` = @UseDate" : "`UseDate` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (useDate.HasValue)
				paras_.Add(Database.CreateInParameter("@UseDate", useDate.Value, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUseDateAsync(DateTime? useDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(useDate.HasValue ? "`UseDate` = @UseDate" : "`UseDate` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (useDate.HasValue)
				paras_.Add(Database.CreateInParameter("@UseDate", useDate.Value, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		#endregion // GetByUseDate
		#region GetByUserID
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID)
		{
			return GetByUserID(userID, 0, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, int top_)
		{
			return GetByUserID(userID, top_, string.Empty, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, int top_)
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
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, int top_, TransactionManager tm_)
		{
			return GetByUserID(userID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, int top_, TransactionManager tm_)
		{
			return await GetByUserIDAsync(userID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 UserID（字段） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, string sort_)
		{
			return GetByUserID(userID, 0, sort_, null);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, string sort_)
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
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, string sort_, TransactionManager tm_)
		{
			return GetByUserID(userID, 0, sort_, tm_);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, string sort_, TransactionManager tm_)
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
		public List<Sb_bank_spei_codeEO> GetByUserID(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userID != null ? "`UserID` = @UserID" : "`UserID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userID != null)
				paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		public async Task<List<Sb_bank_spei_codeEO>> GetByUserIDAsync(string userID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(userID != null ? "`UserID` = @UserID" : "`UserID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (userID != null)
				paras_.Add(Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_bank_spei_codeEO.MapDataReader);
		}
		#endregion // GetByUserID
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
