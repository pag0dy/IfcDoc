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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("96c563dd-8109-4f17-ba35-277ff9ab904a")]
	public partial class IfcUnitAssignment
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcUnit> _Units = new HashSet<IfcUnit>();
	
	
		[Description("Units to be included within a unit assignment.")]
		public ISet<IfcUnit> Units { get { return this._Units; } }
	
	
	}
	
}
