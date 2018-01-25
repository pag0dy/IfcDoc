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
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("4a632b06-c26a-4fb7-b059-9f59ca2ffc55")]
	public partial class IfcAnnotationFillAreaOccurrence : IfcAnnotationOccurrence
	{
		[DataMember(Order=0)] 
		IfcPoint _FillStyleTarget;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcGlobalOrLocalEnum? _GlobalOrLocal;
	
	
		[Description(@"<EPM-HTML>The point that specifies the starting location for the fill area style assigned to the annotation fill area occurrence. Depending on the attribute <i>GlobalOrLocal</i> the point is either given within the world coordinate system of the project or within the object coordinate system of the element or annotation. If the <i>FillStyleTarget</i> is not given, it defaults to 0.,0.
	  <blockquote><small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute has been made OPTIONAL.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPoint FillStyleTarget { get { return this._FillStyleTarget; } set { this._FillStyleTarget = value;} }
	
		[Description(@"<EPM-HTML>The coordinate system in which the <i>FillStyleTarget</i> point is given. Depending on the attribute <i>GlobalOrLocal</i> the point is either given within the world coordinate system of the project or within the object coordinate system of the element or annotation. If not given, the hatch style is directly applied to the parameterization of the geometric representation item, e.g. to the surface coordinate sytem, defined by the surface normal.
	  <blockquote><small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute has been added.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcGlobalOrLocalEnum? GlobalOrLocal { get { return this._GlobalOrLocal; } set { this._GlobalOrLocal = value;} }
	
	
	}
	
}
