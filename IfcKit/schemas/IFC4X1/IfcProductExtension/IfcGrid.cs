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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("25379845-b692-4288-a06e-0e6782212371")]
	public partial class IfcGrid : IfcPositioningElement
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcGridAxis> _UAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcGridAxis> _VAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=2)] 
		[MinLength(1)]
		IList<IfcGridAxis> _WAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcGridTypeEnum? _PredefinedType;
	
	
		public IfcGrid()
		{
		}
	
		public IfcGrid(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcGridAxis[] __UAxes, IfcGridAxis[] __VAxes, IfcGridAxis[] __WAxes, IfcGridTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._UAxes = new List<IfcGridAxis>(__UAxes);
			this._VAxes = new List<IfcGridAxis>(__VAxes);
			this._WAxes = new List<IfcGridAxis>(__WAxes);
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("List of grid axes defining the first row of grid lines.")]
		public IList<IfcGridAxis> UAxes { get { return this._UAxes; } }
	
		[Description("List of grid axes defining the second row of grid lines.")]
		public IList<IfcGridAxis> VAxes { get { return this._VAxes; } }
	
		[Description("List of grid axes defining the third row of grid lines. It may be given in the ca" +
	    "se of a triangular grid.")]
		public IList<IfcGridAxis> WAxes { get { return this._WAxes; } }
	
		[Description("Predefined types to define the particular type of the grid. \r\n<blockquote class=\"" +
	    "change-ifc4\">IFC4 Change&nbsp; New attribute.</blockquote>")]
		public IfcGridTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
