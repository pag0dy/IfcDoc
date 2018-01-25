// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	[Guid("6568e6cb-93db-4698-822f-33bbc35a1144")]
	public partial class IfcTable :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		String _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcTableRow> _Rows = new List<IfcTableRow>();
	
	
		[Description("A unique name which is intended to describe the usage of the Table.")]
		public String Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Reference to information content of rows.")]
		public IList<IfcTableRow> Rows { get { return this._Rows; } }
	
	
	}
	
}
