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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("72a45e5a-521d-4b77-ba81-0938e73dffff")]
	public partial class IfcIndexedColourMap : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcTessellatedFaceSet _MappedTo;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcSurfaceStyleShading")]
		IfcSurfaceStyleShading _Overrides;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcColourRgbList")]
		[Required()]
		IfcColourRgbList _Colours;
	
		[DataMember(Order=3)] 
		[Required()]
		IList<Int64> _ColourIndex = new List<Int64>();
	
	
		[Description("<EPM-HTML>\r\nReference to the <em>IfcTessellatedFaceSet</em> to which it applies t" +
	    "he colours.\r\n</EPM-HTML>")]
		public IfcTessellatedFaceSet MappedTo { get { return this._MappedTo; } set { this._MappedTo = value;} }
	
		[Description("<EPM-HTML>\r\nIndication that the <em>IfcIndexedColourMap</em> overrides the surfac" +
	    "e colour information that might be assigned as an <em>IfcStyledItem</em> to the " +
	    "<em>IfcTessellatedFaceSet</em>.\r\n</EPM-HTML>")]
		public IfcSurfaceStyleShading Overrides { get { return this._Overrides; } set { this._Overrides = value;} }
	
		[Description("<EPM-HTML>\r\nIndexable list of RGB colours.\r\n</EPM-HTML>")]
		public IfcColourRgbList Colours { get { return this._Colours; } set { this._Colours = value;} }
	
		[Description("<EPM-HTML>\r\nIndex into the <em>IfcColourRgbList</em> for each face of the <em>Ifc" +
	    "TriangulatedFaceSet</em>. The colour is applied uniformly to the face.\r\n</EPM-HT" +
	    "ML>")]
		public IList<Int64> ColourIndex { get { return this._ColourIndex; } }
	
	
	}
	
}
