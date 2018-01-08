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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("0bb46add-edf1-4a43-98f9-99b82f3b893a")]
	public abstract partial class IfcReinforcingElement : IfcBuildingElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _SteelGrade;
	
	
		[Description("The nominal steel grade defined according to local standards.")]
		public IfcLabel? SteelGrade { get { return this._SteelGrade; } set { this._SteelGrade = value;} }
	
	
	}
	
}
