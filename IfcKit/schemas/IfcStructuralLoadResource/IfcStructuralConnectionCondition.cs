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

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	public abstract partial class IfcStructuralConnectionCondition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Optionally defines a name for this connection condition.")]
		public IfcLabel? Name { get; set; }
	
	
		protected IfcStructuralConnectionCondition(IfcLabel? __Name)
		{
			this.Name = __Name;
		}
	
	
	}
	
}
