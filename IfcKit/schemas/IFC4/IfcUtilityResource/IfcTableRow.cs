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
	[Guid("a925bebd-3061-4c03-b8e4-527792999e24")]
	public partial class IfcTableRow
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcValue> _RowCells = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _IsHeading;
	
		[InverseProperty("Rows")] 
		IfcTable _OfTable;
	
	
		[Description(@"The value of information by row and column using the units defined. NOTE - The row value identifies both the actual value and the units in which it is recorded. Each cell (unique row and column) may have a different value AND different units. If the row is a heading row, then the row values are strings defined by the IfcString.")]
		public IList<IfcValue> RowCells { get { return this._RowCells; } }
	
		[Description("Flag which identifies if the row is a heading row or a row which contains row val" +
	    "ues. NOTE - If the row is a heading, the flag takes the value = TRUE.")]
		public Boolean IsHeading { get { return this._IsHeading; } set { this._IsHeading = value;} }
	
		[Description("Reference to the IfcTable, in which the IfcTableRow is defined (or contained).")]
		public IfcTable OfTable { get { return this._OfTable; } set { this._OfTable = value;} }
	
	
	}
	
}
