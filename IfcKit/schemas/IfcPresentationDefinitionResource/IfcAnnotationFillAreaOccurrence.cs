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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcAnnotationFillAreaOccurrence : IfcAnnotationOccurrence
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>The point that specifies the starting location for the fill area style assigned to the annotation fill area occurrence. Depending on the attribute <i>GlobalOrLocal</i> the point is either given within the world coordinate system of the project or within the object coordinate system of the element or annotation. If the <i>FillStyleTarget</i> is not given, it defaults to 0.,0.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute has been made OPTIONAL.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcPoint FillStyleTarget { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<EPM-HTML>The coordinate system in which the <i>FillStyleTarget</i> point is given. Depending on the attribute <i>GlobalOrLocal</i> the point is either given within the world coordinate system of the project or within the object coordinate system of the element or annotation. If not given, the hatch style is directly applied to the parameterization of the geometric representation item, e.g. to the surface coordinate sytem, defined by the surface normal.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute has been added.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcGlobalOrLocalEnum? GlobalOrLocal { get; set; }
	
	
		public IfcAnnotationFillAreaOccurrence(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name, IfcPoint __FillStyleTarget, IfcGlobalOrLocalEnum? __GlobalOrLocal)
			: base(__Item, __Styles, __Name)
		{
			this.FillStyleTarget = __FillStyleTarget;
			this.GlobalOrLocal = __GlobalOrLocal;
		}
	
	
	}
	
}
