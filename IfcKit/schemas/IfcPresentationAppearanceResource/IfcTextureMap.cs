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

using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextureMap : IfcTextureCoordinate
	{
		[DataMember(Order = 0)] 
		[Description("List of texture coordinate vertices that are applied to the corresponding points of the polyloop defining a face bound.")]
		[Required()]
		[MinLength(3)]
		public IList<IfcTextureVertex> Vertices { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The face that defines the corresponding list of points along the bounding poly loop of the face outer bound.  <blockquote class=\"note\">NOTE&nbsp; The face may have additional inner loops. The <em>IfcTextureMap</em> and its <em>Vertices</em> only correspond with the coordinates of the <em>IfcPolyloop</em> representing the outer bound.</blockquote>")]
		[Required()]
		public IfcFace MappedTo { get; set; }
	
	
		public IfcTextureMap(IfcSurfaceTexture[] __Maps, IfcTextureVertex[] __Vertices, IfcFace __MappedTo)
			: base(__Maps)
		{
			this.Vertices = new List<IfcTextureVertex>(__Vertices);
			this.MappedTo = __MappedTo;
		}
	
	
	}
	
}
