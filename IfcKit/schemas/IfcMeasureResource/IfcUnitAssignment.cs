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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcUnitAssignment
	{
		[DataMember(Order = 0)] 
		[Description("Units to be included within a unit assignment.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcUnit> Units { get; protected set; }
	
	
		public IfcUnitAssignment(IfcUnit[] __Units)
		{
			this.Units = new HashSet<IfcUnit>(__Units);
		}
	
	
	}
	
}
