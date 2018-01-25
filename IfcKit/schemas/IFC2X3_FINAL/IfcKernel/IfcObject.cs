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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("74eff30d-3146-4508-81e8-7ea78f81a9b2")]
	public abstract partial class IfcObject : IfcObjectDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ObjectType;
	
		[InverseProperty("RelatedObjects")] 
		ISet<IfcRelDefines> _IsDefinedBy = new HashSet<IfcRelDefines>();
	
	
		[Description(@"<EPM-HTML>
	The type denotes a particular type that indicates the object further. The use has to be established at the level of instantiable subtypes. In particular it holds the user defined type, if the enumeration of the attribute <i>PredefinedType</i> is set to USERDEFINED. 
	<br>
	</EPM-HTML>")]
		public IfcLabel? ObjectType { get { return this._ObjectType; } set { this._ObjectType = value;} }
	
		[Description(@"<EPM-HTML>
	Set of relationships to type or property (statically or dynamically defined) information that further define the object. In case of type information, the associated <i>IfcTypeObject</i> contains the specific information (or type, or style), that is common to all instances of <i>IfcObject</i> referring to the same type.
	<br>
	</EPM-HTML>")]
		public ISet<IfcRelDefines> IsDefinedBy { get { return this._IsDefinedBy; } }
	
	
	}
	
}
