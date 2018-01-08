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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("b816352c-9e44-415c-8563-b3e3eafb9357")]
	public partial class IfcRelConnectsPathElements : IfcRelConnectsElements
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<Int64> _RelatingPriorities = new List<Int64>();
	
		[DataMember(Order=1)] 
		[Required()]
		IList<Int64> _RelatedPriorities = new List<Int64>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatedConnectionType;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatingConnectionType;
	
	
		[Description("Priorities for connection. It refers to the layers of the RelatingObject.\r\n")]
		public IList<Int64> RelatingPriorities { get { return this._RelatingPriorities; } }
	
		[Description("Priorities for connection. It refers to the layers of the RelatedObject.\r\n")]
		public IList<Int64> RelatedPriorities { get { return this._RelatedPriorities; } }
	
		[Description("Indication of the connection type in relation to the path of the RelatingObject.\r" +
	    "\n")]
		public IfcConnectionTypeEnum RelatedConnectionType { get { return this._RelatedConnectionType; } set { this._RelatedConnectionType = value;} }
	
		[Description("Indication of the connection type in relation to the path of the RelatingObject.\r" +
	    "\n")]
		public IfcConnectionTypeEnum RelatingConnectionType { get { return this._RelatingConnectionType; } set { this._RelatingConnectionType = value;} }
	
	
	}
	
}
