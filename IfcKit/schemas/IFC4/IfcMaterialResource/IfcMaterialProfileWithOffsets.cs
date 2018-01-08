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
	[Guid("d4e70fb0-cafe-4e54-a0ae-0074daa2942a")]
	public partial class IfcMaterialProfileWithOffsets : IfcMaterialProfile
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _OffsetValues;
	
	
		[Description(@"<EPM-HTML>
	The numerical value of profile offset, in the direction of the axis direction - always AXIS1 that is, the axis along the extrusion path. The <em>OffsetValues[1]</em> identifies the offset from the lower position along the axis direction (normally the start of the standard extrusion), the <em>OffsetValues[2]</em> identifies the offset from the upper position along the axis direction (normally the end of the standard extrusion).
	</EPM-HTML>")]
		public IfcLengthMeasure OffsetValues { get { return this._OffsetValues; } set { this._OffsetValues = value;} }
	
	
	}
	
}
