/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-06-04 15: 39:29
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
	/// 运营商的提现策略区间配置表
	/// 【表 sc_cash_oper_templ 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_oper_templEO : IRowMapper<Sc_cash_oper_templEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_oper_templEO()
		{
			this.TempNum = 0;
			this.PayCashRatioStart = 0.00m;
			this.PayCashRatioEnd = 0.00m;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalOperTempID;
		/// <summary>
		/// 【数据库中的原始主键 OperTempID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalOperTempID
		{
			get { return _originalOperTempID; }
			set { HasOriginal = true; _originalOperTempID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "OperTempID", OperTempID }, };
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
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string OperTempID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 2)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 模板编号
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 3)]
		public int TempNum { get; set; }
		/// <summary>
		/// 充提比下限
		/// 【字段 decimal(65,2)】
		/// </summary>
		[DataMember(Order = 4)]
		public decimal PayCashRatioStart { get; set; }
		/// <summary>
		/// 充提比上限
		/// 【字段 decimal(65,2)】
		/// </summary>
		[DataMember(Order = 5)]
		public decimal PayCashRatioEnd { get; set; }
		/// <summary>
		/// 记录时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 6)]
		public DateTime RecDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_oper_templEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_oper_templEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_oper_templEO ret = new Sc_cash_oper_templEO();
			ret.OperTempID = reader.ToString("OperTempID");
			ret.OriginalOperTempID = ret.OperTempID;
			ret.OperatorID = reader.ToString("OperatorID");
			ret.TempNum = reader.ToInt32("TempNum");
			ret.PayCashRatioStart = reader.ToDecimal("PayCashRatioStart");
			ret.PayCashRatioEnd = reader.ToDecimal("PayCashRatioEnd");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 运营商的提现策略区间配置表
	/// 【表 sc_cash_oper_templ 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_oper_templMO : MySqlTableMO<Sc_cash_oper_templEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_oper_templ`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_oper_templMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_oper_templMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_oper_templMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_oper_templEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_cash_oper_templEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_cash_oper_templEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperTempID`, `OperatorID`, `TempNum`, `PayCashRatioStart`, `PayCashRatioEnd`, `RecDate`) VALUE (@OperTempID, @OperatorID, @TempNum, @PayCashRatioStart, @PayCashRatioEnd, @RecDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", item.OperTempID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@TempNum", item.TempNum, MySqlDbType.Int32),
				Database.CreateInParameter("@PayCashRatioStart", item.PayCashRatioStart, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@PayCashRatioEnd", item.PayCashRatioEnd, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_oper_templEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_oper_templEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_oper_templEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OperTempID`, `OperatorID`, `TempNum`, `PayCashRatioStart`, `PayCashRatioEnd`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OperTempID}','{item.OperatorID}',{item.TempNum},{item.PayCashRatioStart},{item.PayCashRatioEnd},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string operTempID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operTempID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operTempID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string operTempID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_oper_templEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OperTempID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_oper_templEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.OperTempID, tm_);
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
		#region RemoveByTempNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTempNum(int tempNum, TransactionManager tm_ = null)
		{
			RepairRemoveByTempNumData(tempNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTempNumAsync(int tempNum, TransactionManager tm_ = null)
		{
			RepairRemoveByTempNumData(tempNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTempNumData(int tempNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TempNum` = @TempNum";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32));
		}
		#endregion // RemoveByTempNum
		#region RemoveByPayCashRatioStart
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayCashRatioStart(decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			RepairRemoveByPayCashRatioStartData(payCashRatioStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayCashRatioStartAsync(decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			RepairRemoveByPayCashRatioStartData(payCashRatioStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayCashRatioStartData(decimal payCashRatioStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayCashRatioStart` = @PayCashRatioStart";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByPayCashRatioStart
		#region RemoveByPayCashRatioEnd
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPayCashRatioEnd(decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByPayCashRatioEndData(payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPayCashRatioEndAsync(decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByPayCashRatioEndData(payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPayCashRatioEndData(decimal payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `PayCashRatioEnd` = @PayCashRatioEnd";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal));
		}
		#endregion // RemoveByPayCashRatioEnd
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
		public int Put(Sc_cash_oper_templEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_oper_templEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_oper_templEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperTempID` = @OperTempID, `OperatorID` = @OperatorID, `TempNum` = @TempNum, `PayCashRatioStart` = @PayCashRatioStart, `PayCashRatioEnd` = @PayCashRatioEnd WHERE `OperTempID` = @OperTempID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", item.OperTempID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@TempNum", item.TempNum, MySqlDbType.Int32),
				Database.CreateInParameter("@PayCashRatioStart", item.PayCashRatioStart, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@PayCashRatioEnd", item.PayCashRatioEnd, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OperTempID_Original", item.HasOriginal ? item.OriginalOperTempID : item.OperTempID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_oper_templEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_oper_templEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "operTempID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operTempID, string set_, params object[] values_)
		{
			return Put(set_, "`OperTempID` = @OperTempID", ConcatValues(values_, operTempID));
		}
		public async Task<int> PutByPKAsync(string operTempID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`OperTempID` = @OperTempID", ConcatValues(values_, operTempID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operTempID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`OperTempID` = @OperTempID", tm_, ConcatValues(values_, operTempID));
		}
		public async Task<int> PutByPKAsync(string operTempID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`OperTempID` = @OperTempID", tm_, ConcatValues(values_, operTempID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operTempID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`OperTempID` = @OperTempID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string operTempID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`OperTempID` = @OperTempID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(string operTempID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(operTempID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(string operTempID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(operTempID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(string operTempID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
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
		#region PutTempNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTempNumByPK(string operTempID, int tempNum, TransactionManager tm_ = null)
		{
			RepairPutTempNumByPKData(operTempID, tempNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTempNumByPKAsync(string operTempID, int tempNum, TransactionManager tm_ = null)
		{
			RepairPutTempNumByPKData(operTempID, tempNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTempNumByPKData(string operTempID, int tempNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TempNum` = @TempNum  WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32),
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTempNum(int tempNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TempNum` = @TempNum";
			var parameter_ = Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTempNumAsync(int tempNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TempNum` = @TempNum";
			var parameter_ = Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTempNum
		#region PutPayCashRatioStart
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayCashRatioStartByPK(string operTempID, decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			RepairPutPayCashRatioStartByPKData(operTempID, payCashRatioStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayCashRatioStartByPKAsync(string operTempID, decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			RepairPutPayCashRatioStartByPKData(operTempID, payCashRatioStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayCashRatioStartByPKData(string operTempID, decimal payCashRatioStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayCashRatioStart` = @PayCashRatioStart  WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayCashRatioStart(decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayCashRatioStart` = @PayCashRatioStart";
			var parameter_ = Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayCashRatioStartAsync(decimal payCashRatioStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayCashRatioStart` = @PayCashRatioStart";
			var parameter_ = Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayCashRatioStart
		#region PutPayCashRatioEnd
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayCashRatioEndByPK(string operTempID, decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			RepairPutPayCashRatioEndByPKData(operTempID, payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPayCashRatioEndByPKAsync(string operTempID, decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			RepairPutPayCashRatioEndByPKData(operTempID, payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPayCashRatioEndByPKData(string operTempID, decimal payCashRatioEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PayCashRatioEnd` = @PayCashRatioEnd  WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal),
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPayCashRatioEnd(decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayCashRatioEnd` = @PayCashRatioEnd";
			var parameter_ = Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPayCashRatioEndAsync(decimal payCashRatioEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PayCashRatioEnd` = @PayCashRatioEnd";
			var parameter_ = Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPayCashRatioEnd
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string operTempID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operTempID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string operTempID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operTempID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string operTempID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `OperTempID` = @OperTempID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
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
		public bool Set(Sc_cash_oper_templEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperTempID) == null)
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
		public async Task<bool> SetAsync(Sc_cash_oper_templEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperTempID) == null)
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
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_oper_templEO GetByPK(string operTempID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operTempID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<Sc_cash_oper_templEO> GetByPKAsync(string operTempID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operTempID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		private void RepairGetByPKData(string operTempID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`OperTempID` = @OperTempID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TempNum（字段）
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetTempNumByPK(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`TempNum`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		public async Task<int> GetTempNumByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`TempNum`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayCashRatioStart（字段）
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetPayCashRatioStartByPK(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`PayCashRatioStart`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		public async Task<decimal> GetPayCashRatioStartByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`PayCashRatioStart`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PayCashRatioEnd（字段）
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public decimal GetPayCashRatioEndByPK(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (decimal)GetScalar("`PayCashRatioEnd`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		public async Task<decimal> GetPayCashRatioEndByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (decimal)await GetScalarAsync("`PayCashRatioEnd`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "operTempID">主键</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string operTempID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperTempID", operTempID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`OperTempID` = @OperTempID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_oper_templEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByTempNum
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum)
		{
			return GetByTempNum(tempNum, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum)
		{
			return await GetByTempNumAsync(tempNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, TransactionManager tm_)
		{
			return GetByTempNum(tempNum, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, TransactionManager tm_)
		{
			return await GetByTempNumAsync(tempNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, int top_)
		{
			return GetByTempNum(tempNum, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, int top_)
		{
			return await GetByTempNumAsync(tempNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, int top_, TransactionManager tm_)
		{
			return GetByTempNum(tempNum, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, int top_, TransactionManager tm_)
		{
			return await GetByTempNumAsync(tempNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, string sort_)
		{
			return GetByTempNum(tempNum, 0, sort_, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, string sort_)
		{
			return await GetByTempNumAsync(tempNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, string sort_, TransactionManager tm_)
		{
			return GetByTempNum(tempNum, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, string sort_, TransactionManager tm_)
		{
			return await GetByTempNumAsync(tempNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TempNum（字段） 查询
		/// </summary>
		/// /// <param name = "tempNum">模板编号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByTempNum(int tempNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TempNum` = @TempNum", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByTempNumAsync(int tempNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TempNum` = @TempNum", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempNum", tempNum, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		#endregion // GetByTempNum
		#region GetByPayCashRatioStart
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart)
		{
			return GetByPayCashRatioStart(payCashRatioStart, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, TransactionManager tm_)
		{
			return GetByPayCashRatioStart(payCashRatioStart, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, TransactionManager tm_)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, int top_)
		{
			return GetByPayCashRatioStart(payCashRatioStart, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, int top_)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, int top_, TransactionManager tm_)
		{
			return GetByPayCashRatioStart(payCashRatioStart, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, int top_, TransactionManager tm_)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, string sort_)
		{
			return GetByPayCashRatioStart(payCashRatioStart, 0, sort_, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, string sort_)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, string sort_, TransactionManager tm_)
		{
			return GetByPayCashRatioStart(payCashRatioStart, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, string sort_, TransactionManager tm_)
		{
			return await GetByPayCashRatioStartAsync(payCashRatioStart, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioStart（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioStart">充提比下限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioStart(decimal payCashRatioStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayCashRatioStart` = @PayCashRatioStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioStartAsync(decimal payCashRatioStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayCashRatioStart` = @PayCashRatioStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioStart", payCashRatioStart, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		#endregion // GetByPayCashRatioStart
		#region GetByPayCashRatioEnd
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, TransactionManager tm_)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, TransactionManager tm_)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, int top_)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, int top_)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, int top_, TransactionManager tm_)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, int top_, TransactionManager tm_)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, string sort_)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, 0, sort_, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, string sort_)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, string sort_, TransactionManager tm_)
		{
			return GetByPayCashRatioEnd(payCashRatioEnd, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, string sort_, TransactionManager tm_)
		{
			return await GetByPayCashRatioEndAsync(payCashRatioEnd, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PayCashRatioEnd（字段） 查询
		/// </summary>
		/// /// <param name = "payCashRatioEnd">充提比上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByPayCashRatioEnd(decimal payCashRatioEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayCashRatioEnd` = @PayCashRatioEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByPayCashRatioEndAsync(decimal payCashRatioEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`PayCashRatioEnd` = @PayCashRatioEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@PayCashRatioEnd", payCashRatioEnd, MySqlDbType.NewDecimal));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		#endregion // GetByPayCashRatioEnd
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, int top_)
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
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">记录时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, string sort_)
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
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_oper_templEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		public async Task<List<Sc_cash_oper_templEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_oper_templEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
