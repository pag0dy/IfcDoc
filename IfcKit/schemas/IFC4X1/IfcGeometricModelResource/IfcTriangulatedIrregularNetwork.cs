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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("e312d865-7031-4404-9644-cb13ee236f46")]
	public partial class IfcTriangulatedIrregularNetwork : IfcTriangulatedFaceSet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _Flags = new List<IfcInteger>();
	
	
		[Description(@"Indicates attributes of each triangle in a compact form as follows: -2 = invisible void; -1 = invisible hole; 0 = no breaklines; 1 = breakline at edge 1; 2 = breakline at edge 2; 3 = breakline at edges 1 and 2; 4 = breakline at edge 3; 5 = breakline at edges 1 and 3; 6 = breakline at edges 2 and 3; 7 = breakline at edges 1, 2, and 3.")]
		public IList<IfcInteger> Flags { get { return this._Flags; } }
	
	
	}
	
}
