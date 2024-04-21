"use client";
import {
  Bird,
  CornerDownLeft,
  Mic,
  Paperclip,
  Rabbit,
  Turtle,
} from "lucide-react";
import ViewerComp from "@/components/viewer/viewer";

import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";

import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Textarea } from "@/components/ui/textarea";
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
  TooltipProvider,
} from "@/components/ui/tooltip";

import Port from "../viewer/port";
export default function Canvas() {
  return (
    <main>
      <Port />
    </main>
  );
}
