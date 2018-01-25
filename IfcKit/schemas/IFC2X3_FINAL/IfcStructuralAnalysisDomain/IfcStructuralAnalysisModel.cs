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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("b796d1f5-5fcb-4c3a-8308-76c88bd1f02e")]
	public partial class IfcStructuralAnalysisModel : IfcSystem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcAnalysisModelTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		IfcAxis2Placement3D _OrientationOf2DPlane;
	
		[DataMember(Order=2)] 
		ISet<IfcStructuralLoadGroup> _LoadedBy = new HashSet<IfcStructuralLoadGroup>();
	
		[DataMember(Order=3)] 
		ISet<IfcStructuralResultGroup> _HasResults = new HashSet<IfcStructuralResultGroup>();
	
	
		[Description("Defines the type of the structural analysis model. ")]
		public IfcAnalysisModelTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"If the selected model type (PredefinedType) describes a 2D system the orientation is needed to define the upright direction to the focused plane (z-axes). This is needed because all data for the structural analysis model (structural members, structural activities) are defined by using 3-D space. The orientation is given in relation to the coordinate system of the project. By 3D systems this value is not asserted.")]
		public IfcAxis2Placement3D OrientationOf2DPlane { get { return this._OrientationOf2DPlane; } set { this._OrientationOf2DPlane = value;} }
	
		[Description("References to all load groups to be analyzed.")]
		public ISet<IfcStructuralLoadGroup> LoadedBy { get { return this._LoadedBy; } }
	
		[Description("References to all result groups available for this structural analysis model.")]
		public ISet<IfcStructuralResultGroup> HasResults { get { return this._HasResults; } }
	
	
	}
	
}
