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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("e6426bbb-6818-4e03-8b46-0273e8673f1b")]
	public partial class IfcFillAreaStyleTileSymbolWithStyle : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillAreaStyleTileShapeSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAnnotationSymbolOccurrence _Symbol;
	
	
		public IfcFillAreaStyleTileSymbolWithStyle()
		{
		}
	
		public IfcFillAreaStyleTileSymbolWithStyle(IfcAnnotationSymbolOccurrence __Symbol)
		{
			this._Symbol = __Symbol;
		}
	
		[Description("A styled annotation symbol.")]
		public IfcAnnotationSymbolOccurrence Symbol { get { return this._Symbol; } set { this._Symbol = value;} }
	
	
	}
	
}
