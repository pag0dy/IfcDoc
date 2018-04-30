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
		[Description("The data value of the table cell..")]
		[MinLength(1)]
		public IList<IfcValue> RowCells { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Flag which identifies if the row is a heading row or a row which contains row values. <blockquote class=\"note\">NOTE - If the row is a heading, the flag takes the value = TRUE.</blockquote>")]
		public IfcBoolean? IsHeading { get; set; }
	
	
		public IfcTableRow(IfcValue[] __RowCells, IfcBoolean? __IsHeading)
		{
			this.RowCells = new List<IfcValue>(__RowCells);
			this.IsHeading = __IsHeading;
		}
	
	
	}
	
}
