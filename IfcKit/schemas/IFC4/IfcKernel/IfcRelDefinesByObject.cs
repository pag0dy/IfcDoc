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
		[XmlElement("IfcObject")]
		[Required()]
		IfcObject _RelatingObject;
	
	
		[Description("<EPM-HTML>\r\nObjects being part of an object occurrence decomposition, acting as t" +
	    "he \"reflecting parts\" in the relationship.\r\n</EPM-HTML>")]
		public ISet<IfcObject> RelatedObjects { get { return this._RelatedObjects; } }
	
		[Description("<EPM-HTML>\r\nObject being part of an object type decomposition, acting as the \"dec" +
	    "laring part\" in the relationship.\r\n</EPM-HTML>")]
		public IfcObject RelatingObject { get { return this._RelatingObject; } set { this._RelatingObject = value;} }
	
	
	}
	
}
