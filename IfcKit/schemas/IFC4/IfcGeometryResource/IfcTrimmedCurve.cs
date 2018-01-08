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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("ba9fc3b6-e728-4ad6-be84-9a7975944d33")]
	public partial class IfcTrimmedCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCurve")]
		[Required()]
		IfcCurve _BasisCurve;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcTrimmingSelect> _Trim1 = new HashSet<IfcTrimmingSelect>();
	
		[DataMember(Order=2)] 
		[Required()]
		ISet<IfcTrimmingSelect> _Trim2 = new HashSet<IfcTrimmingSelect>();
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean _SenseAgreement;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcTrimmingPreference _MasterRepresentation;
	
	
		[Description("The curve to be trimmed. For curves with multiple representations any parameter v" +
	    "alues given as Trim1 or Trim2 refer to the master representation of the BasisCur" +
	    "ve only.")]
		public IfcCurve BasisCurve { get { return this._BasisCurve; } set { this._BasisCurve = value;} }
	
		[Description("The first trimming point which may be specified as a Cartesian point, as a real p" +
	    "arameter or both.")]
		public ISet<IfcTrimmingSelect> Trim1 { get { return this._Trim1; } }
	
		[Description("The second trimming point which may be specified as a Cartesian point, as a real " +
	    "parameter or both.")]
		public ISet<IfcTrimmingSelect> Trim2 { get { return this._Trim2; } }
	
		[Description("Flag to indicate whether the direction of the trimmed curve agrees with or is opp" +
	    "osed to the direction of the basis curve.")]
		public Boolean SenseAgreement { get { return this._SenseAgreement; } set { this._SenseAgreement = value;} }
	
		[Description("Where both parameter and point are present at either end of the curve this indica" +
	    "tes the preferred form.")]
		public IfcTrimmingPreference MasterRepresentation { get { return this._MasterRepresentation; } set { this._MasterRepresentation = value;} }
	
	
	}
	
}
