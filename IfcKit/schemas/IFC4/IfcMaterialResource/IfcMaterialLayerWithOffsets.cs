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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("7b1a1c54-e0c2-488f-9134-36f48e15796a")]
	public partial class IfcMaterialLayerWithOffsets : IfcMaterialLayer
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLayerSetDirectionEnum _OffsetDirection;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _OffsetValues;
	
	
		[Description("Orientation of the offset; shall be perpendicular to the parent layer set directi" +
	    "on.\r\n")]
		public IfcLayerSetDirectionEnum OffsetDirection { get { return this._OffsetDirection; } set { this._OffsetDirection = value;} }
	
		[Description(@"The numerical value of layer offset, in the direction of the axis assigned by the attribute <em>OffsetDirection</em>. The <em>OffsetValues[1]</em> identifies the offset from the lower position along the axis direction (normally the start of the standard extrusion), the <em>OffsetValues[2]</em> identifies the offset from the upper position along the axis direction (normally the end of the standard extrusion).")]
		public IfcLengthMeasure OffsetValues { get { return this._OffsetValues; } set { this._OffsetValues = value;} }
	
	
	}
	
}
