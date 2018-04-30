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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcZone : IfcSystem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Long name for a zone, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.  <blockquote class=\"note\">NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a zone, and the <em>LongName</em> refers to the full name.    </blockquote>  </br>    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The attribute has been added at the end of the entity definition.</blockquote>")]
		public IfcLabel? LongName { get; set; }
	
	
		public IfcZone(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel? __LongName)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.LongName = __LongName;
		}
	
	
	}
	
}
