﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Time_tracker
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TimeTrickerDb")]
	public partial class sqltoLinqDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTimeTrickTable(TimeTrickTable instance);
    partial void UpdateTimeTrickTable(TimeTrickTable instance);
    partial void DeleteTimeTrickTable(TimeTrickTable instance);
    #endregion
		
		public sqltoLinqDataDataContext() : 
				base(global::Time_tracker.Properties.Settings.Default.TimeTrickerDbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public sqltoLinqDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public sqltoLinqDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public sqltoLinqDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public sqltoLinqDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TimeTrickTable> TimeTrickTables
		{
			get
			{
				return this.GetTable<TimeTrickTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TimeTrickTable")]
	public partial class TimeTrickTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Autoinc;
		
		private System.Nullable<System.DateTime> _EntryDate;
		
		private System.Nullable<System.TimeSpan> _ETime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAutoincChanging(long value);
    partial void OnAutoincChanged();
    partial void OnEntryDateChanging(System.Nullable<System.DateTime> value);
    partial void OnEntryDateChanged();
    partial void OnETimeChanging(System.Nullable<System.TimeSpan> value);
    partial void OnETimeChanged();
    #endregion
		
		public TimeTrickTable()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Autoinc", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Autoinc
		{
			get
			{
				return this._Autoinc;
			}
			set
			{
				if ((this._Autoinc != value))
				{
					this.OnAutoincChanging(value);
					this.SendPropertyChanging();
					this._Autoinc = value;
					this.SendPropertyChanged("Autoinc");
					this.OnAutoincChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryDate", DbType="Date")]
		public System.Nullable<System.DateTime> EntryDate
		{
			get
			{
				return this._EntryDate;
			}
			set
			{
				if ((this._EntryDate != value))
				{
					this.OnEntryDateChanging(value);
					this.SendPropertyChanging();
					this._EntryDate = value;
					this.SendPropertyChanged("EntryDate");
					this.OnEntryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ETime", DbType="Time")]
		public System.Nullable<System.TimeSpan> ETime
		{
			get
			{
				return this._ETime;
			}
			set
			{
				if ((this._ETime != value))
				{
					this.OnETimeChanging(value);
					this.SendPropertyChanging();
					this._ETime = value;
					this.SendPropertyChanged("ETime");
					this.OnETimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
