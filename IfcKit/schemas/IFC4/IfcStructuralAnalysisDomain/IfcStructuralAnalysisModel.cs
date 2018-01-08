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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("2e087fc5-d46f-48f2-82c1-7c7b5162f4c3")]
	public partial class IfcStructuralAnalysisModel : IfcSystem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcAnalysisModelTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcAxis2Placement3D")]
		IfcAxis2Placement3D _OrientationOf2DPlane;
	
		[DataMember(Order=2)] 
		ISet<IfcStructuralLoadGroup> _LoadedBy = new HashSet<IfcStructuralLoadGroup>();
	
		[DataMember(Order=3)] 
		ISet<IfcStructuralResultGroup> _HasResults = new HashSet<IfcStructuralResultGroup>();
	
		[DataMember(Order=4)] 
		[XmlElement("IfcObjectPlacement")]
		IfcObjectPlacement _SharedPlacement;
	
	
		[Description("Defines the type of the structural analysis model. ")]
		public IfcAnalysisModelTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"<EPM-HTML>
	
	If the selected model type (<em>PredefinedType</em>) describes a 2D system, the orientation defines
	the analysis plane (P[1], P[2]) and the normal to the analysis plane (P[3]).  This is needed because
	structural items and activities are always defined in three-dimensional space even if they are
	meant to be analysed in a two-dimensional manner.
	
	<ul>
	<li>In case of predefined type IN_PLANE_LOADING_2D, the analysis is to be performed within the
	projection into the P[1], P[2] plane.</li>
	<li>In case of predefined type OUT_PLANE_LOADING_2D, only the P[3] component of loads and their
	effects is meant to be analyzed.  This is used for beam grids and for typical slab analyses.</li>
	<li>In case of predefined type LOADING_3D, <em>OrientationOf2DPlane</em> shall be omitted.</li>
	</ul>
	
	</EPM-HTML>")]
		public IfcAxis2Placement3D OrientationOf2DPlane { get { return this._OrientationOf2DPlane; } set { this._OrientationOf2DPlane = value;} }
	
		[Description("References to all load groups to be analyzed.")]
		public ISet<IfcStructuralLoadGroup> LoadedBy { get { return this._LoadedBy; } }
	
		[Description("References to all result groups available for this structural analysis model.")]
		public ISet<IfcStructuralResultGroup> HasResults { get { return this._HasResults; } }
	
		[Description(@"<EPM-HTML>
	
	Object placement which shall be common to all items and activities which are grouped into this instance of <em>IfcStructuralAnalysisModel</em>.  This placement establishes a coordinate system which is referred to as 'global coordinate system' in use definitions of various classes of structural items and activities.
	
	<blockquote class=""note"">NOTE&nbsp; Most commonly, but not necessarily, the <em>SharedPlacement</em> is an <em>IfcLocalPlacement</em> whose z axis is parallel with the z axis of the <em>IfcProject</em>'s world coordinate system and directed like the WCS z axis (i.e. pointing &quot;upwards&quot;) or directed against the WCS z axis (i.e. points &quot;downwards&quot;).</blockquote>
	
	<blockquote class=""note"">NOTE&nbsp; Per informal proposition, this attribute is <b>not optional</b> as soon as at least one <em>IfcStructuralItem</em> is grouped into the instance of <em>IfcStructuralAnalysisModel</em>.</blockquote>
	
	</EPM-HTML>")]
		public IfcObjectPlacement SharedPlacement { get { return this._SharedPlacement; } set { this._SharedPlacement = value;} }
	
	
	}
	
}
