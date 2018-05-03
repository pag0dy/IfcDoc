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


namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	public enum IfcMechanicalFastenerTypeEnum
	{
		[Description("A special bolt which is anchored into conrete, stone, or brickwork.")]
		ANCHORBOLT = 1,
	
		[Description("A threaded cylindrical rod that engages with a similarly threaded hole in a nut o" +
	    "r any other part to form a fastener. The mechanical fastener often also includes" +
	    " one or more washers and one or more nuts.")]
		BOLT = 2,
	
		[Description("A cylindrical rod that is driven into holes of the connected pieces.")]
		DOWEL = 3,
	
		[Description("A thin pointed piece of metal that is hammered into materials as a fastener.")]
		NAIL = 4,
	
		[Description("A piece of sheet metal with punched points that overlaps the connected pieces and" +
	    " is pressed into their material.")]
		NAILPLATE = 5,
	
		[Description("A fastening part having a head at one end and the other end being hammered flat a" +
	    "fter being passed through holes in the pieces that are fastened together.")]
		RIVET = 6,
	
		[Description("A fastener with a tapered threaded shank and a slotted head.")]
		SCREW = 7,
	
		[Description("A ring connector that is accepted by ring keyways in the connected pieces; or a t" +
	    "oothed circular or square connector that is pressed into the connected pieces.")]
		SHEARCONNECTOR = 8,
	
		[Description("A doubly pointed piece of metal that is hammered into materials as a fastener.")]
		STAPLE = 9,
	
		[Description("Stud shear connectors are cylindrical fastening parts with a head on one side. On" +
	    " the other side they are welded on steel members for the use in composite steel " +
	    "and concrete structures.")]
		STUDSHEARCONNECTOR = 10,
	
		[Description("User-defined mechanical fastener.")]
		USERDEFINED = -1,
	
		[Description("Undefined mechanical fastener.")]
		NOTDEFINED = 0,
	
	}
}
