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
	[Guid("92a2c20b-4c2f-4ed2-a2f1-5d0591fa26b2")]
	public partial class IfcRelDefinesByType : IfcRelDefines
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		ISet<IfcObject> _RelatedObjects = new HashSet<IfcObject>();
	
		[DataMember(Order=1)] 
		[XmlElement("IfcTypeObject")]
		[Required()]
		IfcTypeObject _RelatingType;
	
	
		public ISet<IfcObject> RelatedObjects { get { return this._RelatedObjects; } }
	
		[Description("Reference to the type (or style) information for that object or set of objects.")]
		public IfcTypeObject RelatingType { get { return this._RelatingType; } set { this._RelatingType = value;} }
	
	
	}
	
}
