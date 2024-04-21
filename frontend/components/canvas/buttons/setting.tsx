"use client";
import React from "react";
import {
  Bird,
  Book,
  Bot,
  Code2,
  CornerDownLeft,
  LifeBuoy,
  Mic,
  Paperclip,
  Rabbit,
  Settings,
  Settings2,
  Share,
  SquareTerminal,
  SquareUser,
  Triangle,
  Turtle,
} from "lucide-react";
import { Label } from "@/components/ui/label";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

import { ReferencedLinks } from "@/lib/links";
import { DrawerClose, DrawerFooter } from "@/components/ui/drawer";

const Setting = ({
  model,
  setModel,
}: {
  model: string | undefined;
  setModel: (model: string | undefined) => void;
}) => {
  return (
    <div
      className="relative w-full hidden flex-col items-start gap-8 md:flex"
      x-chunk="dashboard-03-chunk-0"
    >
      <form className="grid w-full items-start gap-6">
        <fieldset className="grid gap-6 rounded-lg border p-4">
          <div className="grid gap-3">
            <Select value={model} onValueChange={setModel}>
              <SelectTrigger
                id="model"
                className="items-start [&_[data-description]]:hidden"
              >
                <SelectValue placeholder="Select a model" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="wind">
                  <div className="flex items-start gap-3 text-muted-foreground">
                    <Rabbit className="size-5" />
                    <div className="grid gap-0.5">
                      <p>
                        Model{" "}
                        <span className="font-medium text-foreground">
                          {ReferencedLinks.wind.name}
                        </span>
                      </p>
                      <p className="text-xs" data-description>
                        Done by OpenFoam
                      </p>
                    </div>
                  </div>
                </SelectItem>
                <SelectItem value="sun">
                  <div className="flex items-start gap-3 text-muted-foreground">
                    <Bird className="size-5" />
                    <div className="grid gap-0.5">
                      <p>
                        Model{" "}
                        <span className="font-medium text-foreground">
                          {ReferencedLinks.sun.name}
                        </span>
                      </p>
                      <p className="text-xs" data-description>
                        Performance and speed for efficiency.
                      </p>
                    </div>
                  </div>
                </SelectItem>
                <SelectItem value="utci">
                  <div className="flex items-start gap-3 text-muted-foreground">
                    <Bird className="size-5" />
                    <div className="grid gap-0.5">
                      <p>
                        Model{" "}
                        <span className="font-medium text-foreground">
                          {ReferencedLinks.utci.name}
                        </span>
                      </p>
                      <p className="text-xs" data-description>
                        Performance and speed for efficiency.
                      </p>
                    </div>
                  </div>
                </SelectItem>
              </SelectContent>
            </Select>
          </div>
        </fieldset>
      </form>
    </div>
  );
};

export default Setting;
