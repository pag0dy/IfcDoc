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
	[Guid("349d602e-d775-4785-ac74-0632e4fdd015")]
	public partial class IfcRelDefinesByProperties : IfcRelDefines
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		ISet<IfcObjectDefinition> _RelatedObjects = new HashSet<IfcObjectDefinition>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcPropertySetDefinitionSelect _RelatingPropertyDefinition;
	
	
		[Description("Reference to the objects (or single object) to which the property definition appl" +
	    "ies.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Data type promoted fro" +
	    "m subtype <em>IfcObject</em>.\r\n</blockquote>")]
		public ISet<IfcObjectDefinition> RelatedObjects { get { return this._RelatedObjects; } }
	
		[Description("Reference to the property set definition for that object or set of objects.")]
		public IfcPropertySetDefinitionSelect RelatingPropertyDefinition { get { return this._RelatingPropertyDefinition; } set { this._RelatingPropertyDefinition = value;} }
	
	
	}
	
}
