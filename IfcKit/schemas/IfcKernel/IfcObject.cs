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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcObject : IfcObjectDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute <i>PredefinedType</i> is set to USERDEFINED.   <br>  </EPM-HTML>")]
		public IfcLabel? ObjectType { get; set; }
	
		[InverseProperty("RelatedObjects")] 
		[Description("<EPM-HTML>  Set of relationships to type or property (statically or dynamically defined) information that further define the object. In case of type information, the associated <i>IfcTypeObject</i> contains the specific information (or type, or style), that is common to all instances of <i>IfcObject</i> referring to the same type.  <br>  </EPM-HTML>")]
		public ISet<IfcRelDefines> IsDefinedBy { get; protected set; }
	
	
		protected IfcObject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ObjectType = __ObjectType;
			this.IsDefinedBy = new HashSet<IfcRelDefines>();
		}
	
	
	}
	
}
