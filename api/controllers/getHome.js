import userq from "../models/userq.js"
import mongoose from "mongoose"

export default async function getHome(req,res){
    const resTasks = await userq.find({})
    res.status(200).json(resTasks);
}