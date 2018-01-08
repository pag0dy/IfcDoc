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
	[Guid("969c4ab6-0ebd-4847-b70b-76d4d371d4f0")]
	public partial class IfcProject : IfcObject
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Phase;
	
		[DataMember(Order=2)] 
		[Required()]
		ISet<IfcRepresentationContext> _RepresentationContexts = new HashSet<IfcRepresentationContext>();
	
		[DataMember(Order=3)] 
		[Required()]
		IfcUnitAssignment _UnitsInContext;
	
	
		[Description("Long name for the project as used for reference purposes.")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
		[Description("Current project phase, open to interpretation for all project partner, therefore " +
	    "given as IfcString. \r\n")]
		public IfcLabel? Phase { get { return this._Phase; } set { this._Phase = value;} }
	
		[Description(@"Context of the representations used within the project. When the project includes shape representations for its components, one or several geometric representation contexts need to be included that define e.g. the world coordinate system, the coordinate space dimensions, and/or the precision factor.")]
		public ISet<IfcRepresentationContext> RepresentationContexts { get { return this._RepresentationContexts; } }
	
		[Description("Units globally assigned to measure types used within the context of this project." +
	    "")]
		public IfcUnitAssignment UnitsInContext { get { return this._UnitsInContext; } set { this._UnitsInContext = value;} }
	
	
	}
	
}
