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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("03ad1d5a-0288-44a7-b612-096bd45ae66b")]
	public abstract partial class IfcObject : IfcObjectDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ObjectType;
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement]
		[MaxLength(1)]
		ISet<IfcRelDefinesByObject> _IsDeclaredBy = new HashSet<IfcRelDefinesByObject>();
	
		[InverseProperty("RelatingObject")] 
		ISet<IfcRelDefinesByObject> _Declares = new HashSet<IfcRelDefinesByObject>();
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement]
		[MaxLength(1)]
		ISet<IfcRelDefinesByType> _IsTypedBy = new HashSet<IfcRelDefinesByType>();
	
		[InverseProperty("RelatedObjects")] 
		[XmlElement("IfcRelDefinesByProperties")]
		ISet<IfcRelDefinesByProperties> _IsDefinedBy = new HashSet<IfcRelDefinesByProperties>();
	
	
		public IfcObject()
		{
		}
	
		public IfcObject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._ObjectType = __ObjectType;
		}
	
		[Description(@"The type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute <em>PredefinedType</em> is set to USERDEFINED. 
	<br>")]
		public IfcLabel? ObjectType { get { return this._ObjectType; } set { this._ObjectType = value;} }
	
		[Description(@"Link to the relationship object pointing to the declaring object that provides the object definitions for this object occurrence. The declaring object has to be part of an object type decomposition. The associated <em>IfcObject</em>, or its subtypes, contains the specific information (as part of a type, or style, definition), that is common to all reflected instances of the declaring <em>IfcObject</em>, or its subtypes. 
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New inverse relationship, change made with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByObject> IsDeclaredBy { get { return this._IsDeclaredBy; } }
	
		[Description(@"Link to the relationship object pointing to the reflected object(s) that receives the object definitions. The reflected object has to be part of an object occurrence decomposition. The associated <em>IfcObject</em>, or its subtypes, provides the specific information (as part of a type, or style, definition), that is common to all reflected instances of the declaring <em>IfcObject</em>, or its subtypes. 
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New inverse relationship, change made with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByObject> Declares { get { return this._Declares; } }
	
		[Description(@"Set of relationships to the object type that provides the type definitions for this object occurrence. The then associated <em>IfcTypeObject</em>, or its subtypes, contains the specific information (or type, or style), that is common to all instances of <em>IfcObject</em>, or its subtypes, referring to the same type. 
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New inverse relationship, the link to <em>IfcRelDefinesByType</em> had previously be included in the inverse relationship <em>IfcRelDefines</em>. Change made with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByType> IsTypedBy { get { return this._IsTypedBy; } }
	
		[Description(@"Set of relationships to property set definitions attached to this object. Those statically or dynamically defined properties contain alphanumeric information content that further defines the object. 
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcRelDefines</em> to <em>IfcRelDefinesByProperties</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelDefinesByProperties> IsDefinedBy { get { return this._IsDefinedBy; } }
	
	
	}
	
}
