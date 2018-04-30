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
		[Description("The type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute <em>PredefinedType</em> is set to USERDEFINED.   <br>")]
		public IfcLabel? ObjectType { get; set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement]
		[Description("Link to the relationship object pointing to the declaring object that provides the object definitions for this object occurrence. The declaring object has to be part of an object type decomposition. The associated <em>IfcObject</em>, or its subtypes, contains the specific information (as part of a type, or style, definition), that is common to all reflected instances of the declaring <em>IfcObject</em>, or its subtypes.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse relationship, change made with upward compatibility for file based exchange.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcRelDefinesByObject> IsDeclaredBy { get; protected set; }
	
		[InverseProperty("RelatingObject")] 
		[Description("Link to the relationship object pointing to the reflected object(s) that receives the object definitions. The reflected object has to be part of an object occurrence decomposition. The associated <em>IfcObject</em>, or its subtypes, provides the specific information (as part of a type, or style, definition), that is common to all reflected instances of the declaring <em>IfcObject</em>, or its subtypes.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse relationship, change made with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByObject> Declares { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement]
		[Description("Set of relationships to the object type that provides the type definitions for this object occurrence. The then associated <em>IfcTypeObject</em>, or its subtypes, contains the specific information (or type, or style), that is common to all instances of <em>IfcObject</em>, or its subtypes, referring to the same type.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse relationship, the link to <em>IfcRelDefinesByType</em> had previously be included in the inverse relationship <em>IfcRelDefines</em>. Change made with upward compatibility for file based exchange.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcRelDefinesByType> IsTypedBy { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement("IfcRelDefinesByProperties")]
		[Description("Set of relationships to property set definitions attached to this object. Those statically or dynamically defined properties contain alphanumeric information content that further defines the object.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcRelDefines</em> to <em>IfcRelDefinesByProperties</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByProperties> IsDefinedBy { get; protected set; }
	
	
		protected IfcObject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ObjectType = __ObjectType;
			this.IsDeclaredBy = new HashSet<IfcRelDefinesByObject>();
			this.Declares = new HashSet<IfcRelDefinesByObject>();
			this.IsTypedBy = new HashSet<IfcRelDefinesByType>();
			this.IsDefinedBy = new HashSet<IfcRelDefinesByProperties>();
		}
	
	
	}
	
}
