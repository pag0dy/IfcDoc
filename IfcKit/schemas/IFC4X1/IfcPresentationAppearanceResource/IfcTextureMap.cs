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

using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("d3acf0b2-2c3f-4fc7-afb8-e82f32d6fa12")]
	public partial class IfcTextureMap : IfcTextureCoordinate
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(3)]
		IList<IfcTextureVertex> _Vertices = new List<IfcTextureVertex>();
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcFace _MappedTo;
	
	
		public IfcTextureMap()
		{
		}
	
		public IfcTextureMap(IfcSurfaceTexture[] __Maps, IfcTextureVertex[] __Vertices, IfcFace __MappedTo)
			: base(__Maps)
		{
			this._Vertices = new List<IfcTextureVertex>(__Vertices);
			this._MappedTo = __MappedTo;
		}
	
		[Description("List of texture coordinate vertices that are applied to the corresponding points " +
	    "of the polyloop defining a face bound.")]
		public IList<IfcTextureVertex> Vertices { get { return this._Vertices; } }
	
		[Description(@"The face that defines the corresponding list of points along the bounding poly loop of the face outer bound.
	<blockquote class=""note"">NOTE&nbsp; The face may have additional inner loops. The <em>IfcTextureMap</em> and its <em>Vertices</em> only correspond with the coordinates of the <em>IfcPolyloop</em> representing the outer bound.</blockquote>")]
		public IfcFace MappedTo { get { return this._MappedTo; } set { this._MappedTo = value;} }
	
	
	}
	
}
