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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	[Guid("dcf395ca-c227-4340-a8db-8f53ebd905d5")]
	public partial class IfcTableRow
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		IList<IfcValue> _RowCells = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcBoolean? _IsHeading;
	
	
		public IfcTableRow()
		{
		}
	
		public IfcTableRow(IfcValue[] __RowCells, IfcBoolean? __IsHeading)
		{
			this._RowCells = new List<IfcValue>(__RowCells);
			this._IsHeading = __IsHeading;
		}
	
		[Description("The data value of the table cell..")]
		public IList<IfcValue> RowCells { get { return this._RowCells; } }
	
		[Description("Flag which identifies if the row is a heading row or a row which contains row val" +
	    "ues. <blockquote class=\"note\">NOTE - If the row is a heading, the flag takes the" +
	    " value = TRUE.</blockquote>")]
		public IfcBoolean? IsHeading { get { return this._IsHeading; } set { this._IsHeading = value;} }
	
	
	}
	
}
