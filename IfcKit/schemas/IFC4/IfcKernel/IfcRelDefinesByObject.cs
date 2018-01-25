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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("51ba0123-164c-4caf-8ba8-61e9906b07c0")]
	public partial class IfcRelDefinesByObject : IfcRelDefines
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcObject> _RelatedObjects = new HashSet<IfcObject>();
	
		[DataMember(Order=1)] 
		[XmlIgnore]
		[Required()]
		IfcObject _RelatingObject;
	
	
		[Description("Objects being part of an object occurrence decomposition, acting as the \"reflecti" +
	    "ng parts\" in the relationship.")]
		public ISet<IfcObject> RelatedObjects { get { return this._RelatedObjects; } }
	
		[Description("Object being part of an object type decomposition, acting as the \"declaring part\"" +
	    " in the relationship.")]
		public IfcObject RelatingObject { get { return this._RelatingObject; } set { this._RelatingObject = value;} }
	
	
	}
	
}
