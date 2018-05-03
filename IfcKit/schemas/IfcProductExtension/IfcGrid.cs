// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcGrid : IfcPositioningElement
	{
		[DataMember(Order = 0)] 
		[Description("List of grid axes defining the first row of grid lines.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcGridAxis> UAxes { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("List of grid axes defining the second row of grid lines.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcGridAxis> VAxes { get; protected set; }
	
		[DataMember(Order = 2)] 
		[Description("List of grid axes defining the third row of grid lines. It may be given in the case of a triangular grid.")]
		[MinLength(1)]
		public IList<IfcGridAxis> WAxes { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Predefined types to define the particular type of the grid.   <blockquote class=\"change-ifc4\">IFC4 Change&nbsp; New attribute.</blockquote>")]
		public IfcGridTypeEnum? PredefinedType { get; set; }
	
	
		public IfcGrid(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcGridAxis[] __UAxes, IfcGridAxis[] __VAxes, IfcGridAxis[] __WAxes, IfcGridTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.UAxes = new List<IfcGridAxis>(__UAxes);
			this.VAxes = new List<IfcGridAxis>(__VAxes);
			this.WAxes = new List<IfcGridAxis>(__WAxes);
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
