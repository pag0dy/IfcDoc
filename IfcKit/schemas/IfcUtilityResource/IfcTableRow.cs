// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	public partial class IfcTableRow
	{
		[DataMember(Order = 0)] 
		[Description("The value of information by row and column using the units defined. NOTE - The row value identifies both the actual value and the units in which it is recorded. Each cell (unique row and column) may have a different value AND different units. If the row is a heading row, then the row values are strings defined by the IfcString.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcValue> RowCells { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("Flag which identifies if the row is a heading row or a row which contains row values. NOTE - If the row is a heading, the flag takes the value = TRUE.")]
		[Required()]
		public Boolean IsHeading { get; set; }
	
		[InverseProperty("Rows")] 
		[Description("Reference to the IfcTable, in which the IfcTableRow is defined (or contained).")]
		public IfcTable OfTable { get; set; }
	
	
		public IfcTableRow(IfcValue[] __RowCells, Boolean __IsHeading)
		{
			this.RowCells = new List<IfcValue>(__RowCells);
			this.IsHeading = __IsHeading;
		}
	
	
	}
	
}
