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

namespace BuildingSmart.IFC.IfcProfileResource
{
	public abstract partial class IfcProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the type of geometry into which this profile definition shall be resolved, either a curve or a surface area. In case of curve the profile should be referenced by a swept surface, in case of area the profile should be referenced by a swept area solid.")]
		[Required()]
		public IfcProfileTypeEnum ProfileType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Name of the profile type according to some standard profile table. ")]
		public IfcLabel? ProfileName { get; set; }
	
	
		protected IfcProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName)
		{
			this.ProfileType = __ProfileType;
			this.ProfileName = __ProfileName;
		}
	
	
	}
	
}
